using System;
using System.Drawing;
using System.Windows.Forms;
using Project_Programming;

    public partial class ShipEditForm : Form
    {
        private Ship _currentShip;

        // Declaring form elements (text fields)
        private TextBox txtEnginePower, txtDisplacement, txtName;
        private TextBox txtPassengers, txtSits, txtCapacity;
        private Panel panelPassenger;
        private Button btnSave, btnCancel;

        public ShipEditForm(Ship ship)
        {
            _currentShip = ship;

            // Window settings
            this.Text = "Modify Ship Characteristics";
            this.Size = new Size(450, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeCustomComponents();
            LoadShipData();
        }

        // This method manually builds all Labels and TextBoxes on the form
        private void InitializeCustomComponents()
        {
            int top = 20; // Top padding for dynamic layout positioning

            // 1. Header for General Properties
            CreateLabel("General Ship Characteristics:", 20, top, true);
            top += 30;

            // Engine Power
            CreateLabel("1. Engine power (in watts):", 20, top);
            txtEnginePower = CreateTextBox(250, top);
            top += 35;

            // Displacement
            CreateLabel("2. Displacement:", 20, top);
            txtDisplacement = CreateTextBox(250, top);
            top += 35;

            // Ship Name
            CreateLabel("3. Name of the ship:", 20, top);
            txtName = CreateTextBox(250, top);
            top += 45;

            // 2. Separate container panel for passenger specific properties
            panelPassenger = new Panel { Location = new Point(0, top), Size = new Size(450, 160), Visible = false };
            this.Controls.Add(panelPassenger);

            int pTop = 0; // Top padding inside the passenger panel
            CreateLabel("Passenger Characteristics:", 20, pTop, true, panelPassenger);
            pTop += 30;

            CreateLabel("4. Number of passengers:", 20, pTop, false, panelPassenger);
            txtPassengers = CreateTextBox(250, pTop, panelPassenger);
            pTop += 35;

            CreateLabel("5. Number of sits:", 20, pTop, false, panelPassenger);
            txtSits = CreateTextBox(250, pTop, panelPassenger);
            pTop += 35;

            CreateLabel("6. Capacity of sit:", 20, pTop, false, panelPassenger);
            txtCapacity = CreateTextBox(250, pTop, panelPassenger);

            top += 170; // Shifting main window coordinates below the panel

            // 3. Control Buttons (at the very bottom)
            btnSave = new Button { Text = "Apply Changes", Location = new Point(50, top), Size = new Size(150, 40), BackColor = Color.LightGreen };
            btnSave.Click += btnApply_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button { Text = "7. Quit", Location = new Point(230, top), Size = new Size(150, 40) };
            btnCancel.Click += btnQuit_Click;
            this.Controls.Add(btnCancel);
        }

        // Helper method to create standard Labels quickly
        private void CreateLabel(string text, int x, int y, bool isHeader = false, Control parent = null)
        {
            Label lbl = new Label { Text = text, Location = new Point(x, y), AutoSize = true };
            if (isHeader) lbl.Font = new Font(this.Font, FontStyle.Bold);

            if (parent != null) parent.Controls.Add(lbl);
            else this.Controls.Add(lbl);
        }

        // Helper method to create standard TextBoxes quickly
        private TextBox CreateTextBox(int x, int y, Control parent = null)
        {
            TextBox tb = new TextBox { Location = new Point(x, y), Size = new Size(150, 20) };
            if (parent != null) parent.Controls.Add(tb);
            else this.Controls.Add(tb);
            return tb;
        }

        // Loading data from the passed Ship object into the form fields
        private void LoadShipData()
        {
            txtName.Text = _currentShip.NameOfTheShip;
            txtEnginePower.Text = _currentShip.EnginePower.ToString();
            txtDisplacement.Text = _currentShip.Displacement.ToString();

            // Pattern matching: if it's a PassengerShip, reveal fields 4, 5, and 6
            if (_currentShip is PassengerShip passengerShip)
            {
                panelPassenger.Visible = true;
                txtPassengers.Text = passengerShip.Number_of_passengers.ToString();
                txtSits.Text = passengerShip.Number_of_sits.ToString();
                txtCapacity.Text = passengerShip.Capacity_of_sit.ToString();
            }
        }

        // Save logic replacing your original switch/case statement
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Modifying general properties
                _currentShip.NameOfTheShip = txtName.Text;
                _currentShip.EnginePower = Convert.ToDouble(txtEnginePower.Text);
                _currentShip.Displacement = Convert.ToDouble(txtDisplacement.Text);

                // Modifying passenger specific properties if applicable
                if (_currentShip is PassengerShip passengerShip)
                {
                    passengerShip.Number_of_passengers = Convert.ToInt32(txtPassengers.Text);
                    passengerShip.Number_of_sits = Convert.ToInt32(txtSits.Text);
                    passengerShip.Capacity_of_sit = Convert.ToInt32(txtCapacity.Text);
                }

                // Success message (replaces Console.WriteLine notifications)
                MessageBox.Show($"You have modified property of {_currentShip.NameOfTheShip} successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                // Replaces your default case: "You have entered an incorrect number"
                MessageBox.Show("Invalid input format! Please ensure numerical fields contain proper numbers.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

