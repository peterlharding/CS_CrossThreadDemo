using System.Windows.Forms;

namespace CrossThreadDemo
{
    partial class MainForm
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
            this.Txt_Demo = new System.Windows.Forms.TextBox();
            this.Btn_SetText_Unsafe = new System.Windows.Forms.Button();
            this.Btn_SetText_Safe = new System.Windows.Forms.Button();
            this.Btn_SetTextInBackgroundWorker = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Txt_Demo
            // 
            this.Txt_Demo.Location = new System.Drawing.Point(12, 12);
            this.Txt_Demo.Name = "Txt_Demo";
            this.Txt_Demo.Size = new System.Drawing.Size(408, 20);
            this.Txt_Demo.TabIndex = 0;
            // 
            // Btn_SetText_Unsafe
            // 
            this.Btn_SetText_Unsafe.Location = new System.Drawing.Point(15, 55);
            this.Btn_SetText_Unsafe.Name = "Btn_SetText_Unsafe";
            this.Btn_SetText_Unsafe.Size = new System.Drawing.Size(97, 23);
            this.Btn_SetText_Unsafe.TabIndex = 1;
            this.Btn_SetText_Unsafe.Text = "Unsafe Set Text";
            this.Btn_SetText_Unsafe.Click += new System.EventHandler(this.Btn_SetText_Unsafe_Click);
            // 
            // Btn_SetText_Safe
            // 
            this.Btn_SetText_Safe.Location = new System.Drawing.Point(118, 55);
            this.Btn_SetText_Safe.Name = "Btn_SetText_Safe";
            this.Btn_SetText_Safe.Size = new System.Drawing.Size(96, 23);
            this.Btn_SetText_Safe.TabIndex = 2;
            this.Btn_SetText_Safe.Text = "Safe Set Text";
            this.Btn_SetText_Safe.Click += new System.EventHandler(this.Btn_SetText_Safe_Click);
            // 
            // Btn_SetTextInBackgroundWorker
            // 
            this.Btn_SetTextInBackgroundWorker.Location = new System.Drawing.Point(220, 55);
            this.Btn_SetTextInBackgroundWorker.Name = "Btn_SetTextInBackgroundWorker";
            this.Btn_SetTextInBackgroundWorker.Size = new System.Drawing.Size(200, 23);
            this.Btn_SetTextInBackgroundWorker.TabIndex = 3;
            this.Btn_SetTextInBackgroundWorker.Text = "Set Text from Background Worker";
            this.Btn_SetTextInBackgroundWorker.Click += new System.EventHandler(this.Btn_SetTextFromBackgroundWorker_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(431, 96);
            this.Controls.Add(this.Btn_SetTextInBackgroundWorker);
            this.Controls.Add(this.Btn_SetText_Safe);
            this.Controls.Add(this.Btn_SetText_Unsafe);
            this.Controls.Add(this.Txt_Demo);
            this.Name = "MainForm";
            this.Text = "Cross Thred Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Txt_Demo;
        private Button Btn_SetText_Unsafe;
        private Button Btn_SetText_Safe;
        private Button Btn_SetTextInBackgroundWorker;


    }
}

