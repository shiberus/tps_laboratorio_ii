namespace KioscoApp
{
    partial class AdminKiosco
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
            this.labelNombre = new System.Windows.Forms.Label();
            this.listBoxGondola = new System.Windows.Forms.ListBox();
            this.labelGondola = new System.Windows.Forms.Label();
            this.labelHeladera = new System.Windows.Forms.Label();
            this.listBoxHeladera = new System.Windows.Forms.ListBox();
            this.btnNuevoProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnEliminarBebida = new System.Windows.Forms.Button();
            this.btnNuevaBebida = new System.Windows.Forms.Button();
            this.btnEliminarVenta = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.listBoxVenta = new System.Windows.Forms.ListBox();
            this.labelVenta = new System.Windows.Forms.Label();
            this.btnAgrProd = new System.Windows.Forms.Button();
            this.btnAgrBebida = new System.Windows.Forms.Button();
            this.labelRegistradora = new System.Windows.Forms.Label();
            this.btnPersistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNombre.Location = new System.Drawing.Point(12, -2);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(137, 54);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Kiosco";
            // 
            // listBoxGondola
            // 
            this.listBoxGondola.FormattingEnabled = true;
            this.listBoxGondola.ItemHeight = 20;
            this.listBoxGondola.Location = new System.Drawing.Point(12, 153);
            this.listBoxGondola.Name = "listBoxGondola";
            this.listBoxGondola.Size = new System.Drawing.Size(209, 224);
            this.listBoxGondola.TabIndex = 1;
            // 
            // labelGondola
            // 
            this.labelGondola.AutoSize = true;
            this.labelGondola.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGondola.Location = new System.Drawing.Point(12, 104);
            this.labelGondola.Name = "labelGondola";
            this.labelGondola.Size = new System.Drawing.Size(147, 46);
            this.labelGondola.TabIndex = 4;
            this.labelGondola.Text = "Gondola";
            // 
            // labelHeladera
            // 
            this.labelHeladera.AutoSize = true;
            this.labelHeladera.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeladera.Location = new System.Drawing.Point(283, 104);
            this.labelHeladera.Name = "labelHeladera";
            this.labelHeladera.Size = new System.Drawing.Size(154, 46);
            this.labelHeladera.TabIndex = 5;
            this.labelHeladera.Text = "Heladera";
            // 
            // listBoxHeladera
            // 
            this.listBoxHeladera.FormattingEnabled = true;
            this.listBoxHeladera.ItemHeight = 20;
            this.listBoxHeladera.Location = new System.Drawing.Point(283, 153);
            this.listBoxHeladera.Name = "listBoxHeladera";
            this.listBoxHeladera.Size = new System.Drawing.Size(223, 224);
            this.listBoxHeladera.TabIndex = 6;
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.Location = new System.Drawing.Point(12, 383);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(94, 29);
            this.btnNuevoProducto.TabIndex = 7;
            this.btnNuevoProducto.Text = "Nuevo";
            this.btnNuevoProducto.UseVisualStyleBackColor = true;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Location = new System.Drawing.Point(127, 383);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarProducto.TabIndex = 9;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // btnEliminarBebida
            // 
            this.btnEliminarBebida.Location = new System.Drawing.Point(412, 383);
            this.btnEliminarBebida.Name = "btnEliminarBebida";
            this.btnEliminarBebida.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarBebida.TabIndex = 12;
            this.btnEliminarBebida.Text = "Eliminar";
            this.btnEliminarBebida.UseVisualStyleBackColor = true;
            this.btnEliminarBebida.Click += new System.EventHandler(this.btnEliminarBebida_Click);
            // 
            // btnNuevaBebida
            // 
            this.btnNuevaBebida.Location = new System.Drawing.Point(283, 383);
            this.btnNuevaBebida.Name = "btnNuevaBebida";
            this.btnNuevaBebida.Size = new System.Drawing.Size(94, 29);
            this.btnNuevaBebida.TabIndex = 10;
            this.btnNuevaBebida.Text = "Nuevo";
            this.btnNuevaBebida.UseVisualStyleBackColor = true;
            this.btnNuevaBebida.Click += new System.EventHandler(this.btnNuevaBebida_Click);
            // 
            // btnEliminarVenta
            // 
            this.btnEliminarVenta.Location = new System.Drawing.Point(694, 383);
            this.btnEliminarVenta.Name = "btnEliminarVenta";
            this.btnEliminarVenta.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarVenta.TabIndex = 16;
            this.btnEliminarVenta.Text = "Eliminar";
            this.btnEliminarVenta.UseVisualStyleBackColor = true;
            this.btnEliminarVenta.Click += new System.EventHandler(this.btnEliminarVenta_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(565, 383);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(94, 29);
            this.btnVender.TabIndex = 15;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // listBoxVenta
            // 
            this.listBoxVenta.FormattingEnabled = true;
            this.listBoxVenta.ItemHeight = 20;
            this.listBoxVenta.Location = new System.Drawing.Point(565, 153);
            this.listBoxVenta.Name = "listBoxVenta";
            this.listBoxVenta.Size = new System.Drawing.Size(223, 224);
            this.listBoxVenta.TabIndex = 14;
            // 
            // labelVenta
            // 
            this.labelVenta.AutoSize = true;
            this.labelVenta.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelVenta.Location = new System.Drawing.Point(565, 104);
            this.labelVenta.Name = "labelVenta";
            this.labelVenta.Size = new System.Drawing.Size(105, 46);
            this.labelVenta.TabIndex = 13;
            this.labelVenta.Text = "Venta";
            // 
            // btnAgrProd
            // 
            this.btnAgrProd.Location = new System.Drawing.Point(12, 418);
            this.btnAgrProd.Name = "btnAgrProd";
            this.btnAgrProd.Size = new System.Drawing.Size(209, 29);
            this.btnAgrProd.TabIndex = 17;
            this.btnAgrProd.Text = "Agregar a orden";
            this.btnAgrProd.UseVisualStyleBackColor = true;
            this.btnAgrProd.Click += new System.EventHandler(this.btnAgrProd_Click);
            // 
            // btnAgrBebida
            // 
            this.btnAgrBebida.Location = new System.Drawing.Point(283, 418);
            this.btnAgrBebida.Name = "btnAgrBebida";
            this.btnAgrBebida.Size = new System.Drawing.Size(223, 29);
            this.btnAgrBebida.TabIndex = 18;
            this.btnAgrBebida.Text = "Agregar a orden";
            this.btnAgrBebida.UseVisualStyleBackColor = true;
            this.btnAgrBebida.Click += new System.EventHandler(this.btnAgrBebida_Click);
            // 
            // labelRegistradora
            // 
            this.labelRegistradora.AutoSize = true;
            this.labelRegistradora.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRegistradora.Location = new System.Drawing.Point(12, 52);
            this.labelRegistradora.Name = "labelRegistradora";
            this.labelRegistradora.Size = new System.Drawing.Size(247, 54);
            this.labelRegistradora.TabIndex = 19;
            this.labelRegistradora.Text = "Registradora";
            // 
            // btnPersistir
            // 
            this.btnPersistir.Location = new System.Drawing.Point(611, 30);
            this.btnPersistir.Name = "btnPersistir";
            this.btnPersistir.Size = new System.Drawing.Size(139, 53);
            this.btnPersistir.TabIndex = 20;
            this.btnPersistir.Text = "Persistir kiosco";
            this.btnPersistir.UseVisualStyleBackColor = true;
            this.btnPersistir.Click += new System.EventHandler(this.btnPersistir_Click);
            // 
            // AdminKiosco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPersistir);
            this.Controls.Add(this.labelRegistradora);
            this.Controls.Add(this.btnAgrBebida);
            this.Controls.Add(this.btnAgrProd);
            this.Controls.Add(this.btnEliminarVenta);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.listBoxVenta);
            this.Controls.Add(this.labelVenta);
            this.Controls.Add(this.btnEliminarBebida);
            this.Controls.Add(this.btnNuevaBebida);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnNuevoProducto);
            this.Controls.Add(this.listBoxHeladera);
            this.Controls.Add(this.labelHeladera);
            this.Controls.Add(this.labelGondola);
            this.Controls.Add(this.listBoxGondola);
            this.Controls.Add(this.labelNombre);
            this.Name = "AdminKiosco";
            this.Text = "AdminKiosco";
            this.Load += new System.EventHandler(this.AdminKiosco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.ListBox listBoxGondola;
        private System.Windows.Forms.Label labelGondola;
        private System.Windows.Forms.Label labelHeladera;
        private System.Windows.Forms.ListBox listBoxHeladera;
        private System.Windows.Forms.Button btnNuevoProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnEliminarBebida;
        private System.Windows.Forms.Button btnNuevaBebida;
        private System.Windows.Forms.Button btnEliminarVenta;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.ListBox listBoxVenta;
        private System.Windows.Forms.Label labelVenta;
        private System.Windows.Forms.Button btnAgrProd;
        private System.Windows.Forms.Button btnAgrBebida;
        private System.Windows.Forms.Label labelRegistradora;
        private System.Windows.Forms.Button btnPersistir;
    }
}