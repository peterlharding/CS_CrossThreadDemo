using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace CrossThreadDemo
{
    public partial class MainForm : Form
    {

        // This delegate enables asynchronous calls for setting the text property on a TextBox control.

        private delegate void SetTextCallback(string text);

        // This thread is used to demonstrate both thread-safe and unsafe ways to call a Windows Forms control.

        private Thread demoThread = null;

        // This BackgroundWorker is used to demonstrate the preferred way of performing asynchronous operations.

        private BackgroundWorker backgroundWorker;

        //-----------------------------------------------------------------------------------------

        public MainForm()
        {
            InitializeComponent();

        } // MainForm

        //-----------------------------------------------------------------------------------------

        // This event handler creates a thread that calls a Windows Forms control in an unsafe way.

        private void Btn_SetText_Unsafe_Click(object sender, EventArgs e)
        {
            demoThread = new Thread(ThreadProcUnsafe);

            demoThread.Start();

        } // Btn_SetText_Unsafe_Click

        //-----------------------------------------------------------------------------------------
        // This method is executed on the worker thread and makes an unsafe call on the TextBox control.

        private void ThreadProcUnsafe()
        {
            Txt_Demo.Text = @"This text was set unsafely.";

        } // ThreadProcUnsafe

        //-----------------------------------------------------------------------------------------
        // This event handler creates a thread that calls a Windows Forms control in a thread-safe way.

        private void Btn_SetText_Safe_Click(object sender, EventArgs e)
        {
            demoThread = new Thread(ThreadProcSafe);

            demoThread.Start();

        } // Btn_SetText_Safe_Click

        // This method is executed on the worker thread and makes a thread-safe call on the TextBox control.

        private void ThreadProcSafe()
        {
            SetText(@"This text was set safely.");

        } // ThreadProcSafe

        //-----------------------------------------------------------------------------------------
        // This method demonstrates a pattern for making thread-safe calls on a Windows Forms control.  
        // 
        // If the calling thread is different from the thread that created the TextBox control,
        // this method creates a SetTextCallback and calls itself asynchronously using the 
        // Invoke method. 
        // 
        // If the calling thread is the same as the thread that created the TextBox control,
        // the Text property is set directly.  

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the calling thread to the
            // thread ID of the creating thread. If these threads are different, it returns true. 

            if (Txt_Demo.InvokeRequired)
            {
                SetTextCallback d = SetText;
                Invoke(d, text);
            }
            else
            {
                Txt_Demo.Text = text;
            }
        }

        //-----------------------------------------------------------------------------------------
        // This event handler starts the form's BackgroundWorker by calling RunWorkerAsync. 
        // 
        // The Text property of the TextBox control is set when the BackgroundWorker raises
        // the RunWorkerCompleted event.

        private void Btn_SetTextFromBackgroundWorker_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();

        } // Btn_SetTextFromBackgroundWorker_Click

        //-----------------------------------------------------------------------------------------
        // This event handler sets the Text property of the TextBox control. It is called on the
        // thread that created the TextBox control, so the call is thread-safe. 
        // 
        // BackgroundWorker is the preferred way to perform asynchronous operations. 

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Txt_Demo.Text = @"This text was set safely by BackgroundWorker.";

        } // backgroundWorker_RunWorkerCompleted

        //-----------------------------------------------------------------------------------------

    }
}
