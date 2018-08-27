using MandelbrotSetWF.OpenGL;

namespace MandelbrotSetWF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.openGLRender1 = new DischargeRenderContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.xCord = new System.Windows.Forms.ToolStripStatusLabel();
            this.yCord = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openGLRender1
            // 
            this.openGLRender1.Location = new System.Drawing.Point(12, 12);
            this.openGLRender1.Name = "openGLRender1";
            this.openGLRender1.Size = new System.Drawing.Size(700, 700);
            this.openGLRender1.TabIndex = 1;
            this.openGLRender1.OnRender += new System.EventHandler<MandelbrotSetWF.OpenGLRender.OpenGLRenderEventsArgs>(this.openGLRender1_OnRender);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xCord,
            this.yCord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // xCord
            // 
            this.xCord.Name = "xCord";
            this.xCord.Size = new System.Drawing.Size(18, 20);
            this.xCord.Text = "X";
            // 
            // yCord
            // 
            this.yCord.Name = "yCord";
            this.yCord.Size = new System.Drawing.Size(17, 20);
            this.yCord.Text = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 645);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.openGLRender1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DischargeRenderContainer openGLRender1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel xCord;
        private System.Windows.Forms.ToolStripStatusLabel yCord;
    }
}

