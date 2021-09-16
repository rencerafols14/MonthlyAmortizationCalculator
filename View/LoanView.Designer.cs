
namespace MonthlyAmortizationCalculator.View
{
    partial class LoanView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaymentScheduleDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentScheduleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentScheduleDataGridView
            // 
            this.PaymentScheduleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PaymentScheduleDataGridView.Location = new System.Drawing.Point(13, 13);
            this.PaymentScheduleDataGridView.Name = "PaymentScheduleDataGridView";
            this.PaymentScheduleDataGridView.RowTemplate.Height = 25;
            this.PaymentScheduleDataGridView.Size = new System.Drawing.Size(775, 425);
            this.PaymentScheduleDataGridView.TabIndex = 0;
            // 
            // LoanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PaymentScheduleDataGridView);
            this.Name = "LoanView";
            this.Text = "View Loan";
            ((System.ComponentModel.ISupportInitialize)(this.PaymentScheduleDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PaymentScheduleDataGridView;
    }
}