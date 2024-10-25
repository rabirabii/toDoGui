namespace ToDoApp.Ui
{
    partial class EditToDoForm
    {
    
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.Button saveButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {

            this.components = new System.ComponentModel.Container();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.dueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(50, 50);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 22);
            this.Controls.Add(this.titleTextBox);

            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(50, 100);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 22);
            this.Controls.Add(this.descriptionTextBox);

            // 
            // dueDatePicker
            // 
            this.dueDatePicker.Location = new System.Drawing.Point(50, 150);
            this.dueDatePicker.Name = "dueDatePicker";
            this.dueDatePicker.Size = new System.Drawing.Size(200, 22);
            this.Controls.Add(this.dueDatePicker);

            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(50, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_click);
            this.Controls.Add(this.saveButton);

            // 
            // AddToDoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "EditToDoForm";
        }
  
    }
}