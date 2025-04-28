using EsemkaVote2.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EsemkaVote2.View
{
    public partial class EsemkaVote : Form
    {
        private DatabaseConnection _database = new DatabaseConnection();
        private SqlCommand _command;
        private SqlDataAdapter _adapter;
        private SqlDataReader _reader;

        private string base_image = @"D:\EsemkaVote2\EsemkaVote2\assets\";
        private string employeeName;
        public EsemkaVote()
        {
            InitializeComponent();

            LoadDataVotingHeader();
   
        }

        private void EmployeeYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VotingHeaderCombo.SelectedItem is VotingHeaderModel selectedItem)
            {
                HeaderLabel.Text = selectedItem.Name;
                DescLabel.Text = selectedItem.Description;

                EmployeeNameLabel.BorderStyle = 0;
                EmployeeNameLabel.TextAlign = (ContentAlignment)HorizontalAlignment.Center;

                LoadBestEmployee(VotingHeaderCombo.SelectedItem.ToString());
                DisplayVotingDivision();
                DisplayReasonVotedCandidate();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataVotingHeader()
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                const string query = "SELECT Name, Description FROM [VotingHeader] ORDER BY Description ASC";

                using (_command = new SqlCommand(query, connection))
                {
                    using (_reader = _command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            VotingHeaderCombo.Items.Add(new VotingHeaderModel{
                                Name = _reader["Name"].ToString(),
                                Description = _reader["Description"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private int GetTotalVote(string year)
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                const string query = @"select count([VotingDetail].VotedCandidateId) AS TotalVote FROM [VotingDetail]
                                        INNER JOIN [VotingCandidate] ON [VotingDetail].VotedCandidateId = [VotingCandidate].id
                                        INNER JOIN [VotingHeader] ON [VotingHeader].id = [VotingCandidate].VotingHeaderId
                                        WHERE [VotingHeader].Name = @year
                                        GROUP BY [VotingHeader].Name";

                using (_command = new SqlCommand(query, connection))
                {
                    _command.Parameters.AddWithValue("@year", year);

                    using (_reader = _command.ExecuteReader())
                    {
                        int vote = 0;
                        while (_reader.Read())
                        {
                            vote = Convert.ToInt32(_reader["TotalVote"].ToString());
                        }

                        return vote;
                    }
                }
            }
        }

        private void LoadBestEmployee(string year)
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                const string query = @"select TOP 1 [VotingHeader].Name as HeaderName, [Employee].Name, [Employee].Photo, count([VotingDetail].VotedCandidateId) as TotalVote from [VotingDetail]
                                        INNER JOIN [VotingCandidate] ON [VotingCandidate].id = [VotingDetail].VotedCandidateId
                                        INNER JOIN [Employee] ON [Employee].id = [VotingCandidate].EmployeeId
                                        INNER JOIN [VotingHeader] ON [VotingHeader].id = [VotingCandidate].VotingHeaderId
                                        WHERE [VotingHeader].Name = @year
                                        GROUP BY [VotingHeader].Name, [Employee].Name, [Employee].Photo
                                        ORDER BY TotalVote DESC";

                using (_command = new SqlCommand(query, connection))
                {
                    _command.Parameters.AddWithValue("@year", year);

                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.Read())
                        {
                            employeeName = _reader["Name"].ToString();
                            string employeeVote = _reader["TotalVote"].ToString();
                            string employeePhoto = _reader["Photo"].ToString();
                            string imagePath = base_image + employeePhoto;
                            int totalVote = GetTotalVote(year);

                            EmployeeNameLabel.Text = employeeName;
                            VotingCountTotalLabel.Text = totalVote.ToString();
                            VotingCountLabel.Text = employeeVote;
                            EmployeeVotePercentLabel.Text = Math.Ceiling(((Convert.ToDouble(employeeVote) / totalVote) * 100)).ToString() + "%";


                            if (File.Exists(imagePath))
                            {
                                EmployeePicture.Image = new Bitmap(imagePath);
                            } else
                            {
                                EmployeePicture.Image = null;
                                MessageBox.Show(this, "Photo not found!");
                            }
                        }
                    }
                }
            }
        }

        private void DisplayVotingDivision()
        {
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                const string query = @"select [Division].Name as DivisionName ,count(VotedCandidateId) as TotalVote FROM [VotingDetail]
                                        INNER JOIN [VotingCandidate] ON [VotingCandidate].Id = [VotingDetail].VotedCandidateId
                                        INNER JOIN [Employee] ON [Employee].id = [VotingCandidate].EmployeeId
                                        INNER JOIN [Division] ON [Division].Id = [Employee].DivisionId
                                        WHERE [Employee].Name = @EmployeeName
                                        GROUP BY [Division].Name";

                using (_command = new SqlCommand(query, connection))
                {
                    _command.Parameters.AddWithValue("@EmployeeName", employeeName);

                    using (_adapter = new SqlDataAdapter(_command))
                    {
                        DataTable dataTable = new DataTable();
                        _adapter.Fill(dataTable);
                        dataTable.Columns.Add("Percentage", typeof(string));
                        int totalVote = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            totalVote += Convert.ToInt32(row["TotalVote"]);

                            row["Percentage"] = ((Convert.ToDouble(row["TotalVote"]) / totalVote) * 100).ToString() + "%";
                        }

                        VoteDataGridView.DataSource = dataTable;
                        VoteDataGridView.Columns["DivisionName"].HeaderText = "Division Name";
                        VoteDataGridView.Columns["TotalVote"].HeaderText = "Vote Count";
                    }
                }
            }
        }

        private void DisplayReasonVotedCandidate()
        {
            FlowLayoutReason.Controls.Clear();
            using (SqlConnection connection = _database.GetConnection())
            {
                connection.Open();
                const string query = @"select [VotingDetail].Reason FROM [VotingDetail]
                                        inner join [VotingCandidate] ON [VotingCandidate].Id = [VotingDetail].VotedCandidateId
                                        inner join [Employee] ON [VotingCandidate].EmployeeId = [Employee].Id
                                        where [Employee].Name = @EmployeeName AND [VotingDetail].Reason IS NOT NULL";

                using (_command = new SqlCommand(query, connection))
                {
                    _command.Parameters.AddWithValue("@EmployeeName", employeeName);

                    using (_reader = _command.ExecuteReader())
                    {
                        while (_reader.Read())
                        {
                            string reason = _reader["Reason"].ToString();

                            RichTextBox reasonTextBox = new RichTextBox
                            {
                                Width = 239,
                                Height = 201,
                                Text = reason,
                                ReadOnly = true,
                                BorderStyle = BorderStyle.FixedSingle,
                            };

                            FlowLayoutReason.Controls.Add(reasonTextBox);
                        }
                    }
                }
            }
        }
    }
}
