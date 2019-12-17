namespace DGV_VirtualMethod
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.атрибутыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Организация = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.условияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.срокКредитаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.размерКредитаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.клиентBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 193);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(575, 146);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 169);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Показать источник данных";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.атрибутыDataGridViewTextBoxColumn,
            this.Организация,
            this.условияDataGridViewTextBoxColumn,
            this.срокКредитаDataGridViewTextBoxColumn,
            this.размерКредитаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.клиентBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(22, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(601, 141);
            this.dataGridView1.TabIndex = 3;
            // 
            // атрибутыDataGridViewTextBoxColumn
            // 
            this.атрибутыDataGridViewTextBoxColumn.DataPropertyName = "Атрибуты";
            this.атрибутыDataGridViewTextBoxColumn.HeaderText = "Атрибуты";
            this.атрибутыDataGridViewTextBoxColumn.Name = "атрибутыDataGridViewTextBoxColumn";
            // 
            // Организация
            // 
            this.Организация.HeaderText = "Организация";
            this.Организация.Name = "Организация";
            // 
            // условияDataGridViewTextBoxColumn
            // 
            this.условияDataGridViewTextBoxColumn.DataPropertyName = "Условия";
            this.условияDataGridViewTextBoxColumn.HeaderText = "Условия";
            this.условияDataGridViewTextBoxColumn.Name = "условияDataGridViewTextBoxColumn";
            // 
            // срокКредитаDataGridViewTextBoxColumn
            // 
            this.срокКредитаDataGridViewTextBoxColumn.DataPropertyName = "СрокКредита";
            this.срокКредитаDataGridViewTextBoxColumn.HeaderText = "СрокКредита";
            this.срокКредитаDataGridViewTextBoxColumn.Name = "срокКредитаDataGridViewTextBoxColumn";
            // 
            // размерКредитаDataGridViewTextBoxColumn
            // 
            this.размерКредитаDataGridViewTextBoxColumn.DataPropertyName = "РазмерКредита";
            this.размерКредитаDataGridViewTextBoxColumn.HeaderText = "РазмерКредита";
            this.размерКредитаDataGridViewTextBoxColumn.Name = "размерКредитаDataGridViewTextBoxColumn";
            // 
            // клиентBindingSource
            // 
            this.клиентBindingSource.DataSource = typeof(DGV_VirtualMethod.Клиент);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 348);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource клиентBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn атрибутыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Организация;
        private System.Windows.Forms.DataGridViewTextBoxColumn условияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn срокКредитаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn размерКредитаDataGridViewTextBoxColumn;
    }
}

