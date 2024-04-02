namespace WarCad
{
    partial class GraphicsForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsForm));
            this.popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CancelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseBoundary = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.drawTab = new System.Windows.Forms.RibbonTab();
            this.drawPanel = new System.Windows.Forms.RibbonPanel();
            this.arcBtn = new System.Windows.Forms.RibbonButton();
            this.arcBttn1 = new System.Windows.Forms.RibbonButton();
            this.arcBttn2 = new System.Windows.Forms.RibbonButton();
            this.arcBttn3 = new System.Windows.Forms.RibbonButton();
            this.arcBttn4 = new System.Windows.Forms.RibbonButton();
            this.arcBttn5 = new System.Windows.Forms.RibbonButton();
            this.circleBttn = new System.Windows.Forms.RibbonButton();
            this.circleBtn21 = new System.Windows.Forms.RibbonButton();
            this.CircleBtn22 = new System.Windows.Forms.RibbonButton();
            this.ellipseBttn = new System.Windows.Forms.RibbonButton();
            this.ellipseBtn31 = new System.Windows.Forms.RibbonButton();
            this.lineBttn = new System.Windows.Forms.RibbonButton();
            this.poliLineBttn = new System.Windows.Forms.RibbonButton();
            this.poligonBtn = new System.Windows.Forms.RibbonButton();
            this.pointBttn = new System.Windows.Forms.RibbonButton();
            this.rectangleBtn = new System.Windows.Forms.RibbonButton();
            this.drawing = new System.Windows.Forms.PictureBox();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.screen = new System.Windows.Forms.ToolStripStatusLabel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.arcBttn6 = new System.Windows.Forms.RibbonButton();
            this.arcBttn7 = new System.Windows.Forms.RibbonButton();
            this.popup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).BeginInit();
            this.stripStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // popup
            // 
            this.popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelBtn,
            this.CloseBoundary});
            this.popup.Name = "menuStrip";
            this.popup.Size = new System.Drawing.Size(111, 48);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(110, 22);
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CloseBoundary
            // 
            this.CloseBoundary.Name = "CloseBoundary";
            this.CloseBoundary.Size = new System.Drawing.Size(110, 22);
            this.CloseBoundary.Text = "Close";
            this.CloseBoundary.Click += new System.EventHandler(this.closeBoundary_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1204, 175);
            this.ribbon1.TabIndex = 11;
            this.ribbon1.Tabs.Add(this.drawTab);
            this.ribbon1.Text = "ribbon1";
            // 
            // drawTab
            // 
            this.drawTab.Name = "drawTab";
            this.drawTab.Panels.Add(this.drawPanel);
            this.drawTab.Text = "Drawing";
            // 
            // drawPanel
            // 
            this.drawPanel.ButtonMoreEnabled = false;
            this.drawPanel.ButtonMoreVisible = false;
            this.drawPanel.Items.Add(this.arcBtn);
            this.drawPanel.Items.Add(this.circleBttn);
            this.drawPanel.Items.Add(this.ellipseBttn);
            this.drawPanel.Items.Add(this.lineBttn);
            this.drawPanel.Items.Add(this.poliLineBttn);
            this.drawPanel.Items.Add(this.poligonBtn);
            this.drawPanel.Items.Add(this.pointBttn);
            this.drawPanel.Items.Add(this.rectangleBtn);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Text = "";
            // 
            // arcBtn
            // 
            this.arcBtn.DropDownItems.Add(this.arcBttn1);
            this.arcBtn.DropDownItems.Add(this.arcBttn2);
            this.arcBtn.DropDownItems.Add(this.arcBttn3);
            this.arcBtn.DropDownItems.Add(this.arcBttn4);
            this.arcBtn.DropDownItems.Add(this.arcBttn5);
            this.arcBtn.DropDownItems.Add(this.arcBttn6);
            this.arcBtn.DropDownItems.Add(this.arcBttn7);
            this.arcBtn.Image = global::WarCad.Properties.Resources.IconArc;
            this.arcBtn.LargeImage = global::WarCad.Properties.Resources.IconArc;
            this.arcBtn.Name = "arcBtn";
            this.arcBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn.SmallImage")));
            this.arcBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.arcBtn.Text = "Arc";
            // 
            // arcBttn1
            // 
            this.arcBttn1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn1.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn1.Image")));
            this.arcBttn1.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn1.LargeImage")));
            this.arcBttn1.Name = "arcBttn1";
            this.arcBttn1.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn1.SmallImage")));
            this.arcBttn1.Text = "3-Point";
            this.arcBttn1.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBttn2
            // 
            this.arcBttn2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn2.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn2.Image")));
            this.arcBttn2.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn2.LargeImage")));
            this.arcBttn2.Name = "arcBttn2";
            this.arcBttn2.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn2.SmallImage")));
            this.arcBttn2.Text = "Start, Center, End";
            this.arcBttn2.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBttn3
            // 
            this.arcBttn3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn3.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn3.Image")));
            this.arcBttn3.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn3.LargeImage")));
            this.arcBttn3.Name = "arcBttn3";
            this.arcBttn3.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn3.SmallImage")));
            this.arcBttn3.Text = "Center, Start, End";
            this.arcBttn3.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBttn4
            // 
            this.arcBttn4.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn4.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn4.Image")));
            this.arcBttn4.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn4.LargeImage")));
            this.arcBttn4.Name = "arcBttn4";
            this.arcBttn4.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn4.SmallImage")));
            this.arcBttn4.Text = "Center, Start, Angle";
            this.arcBttn4.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBttn5
            // 
            this.arcBttn5.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn5.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn5.Image")));
            this.arcBttn5.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn5.LargeImage")));
            this.arcBttn5.Name = "arcBttn5";
            this.arcBttn5.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn5.SmallImage")));
            this.arcBttn5.Text = "Center, Start, Length";
            this.arcBttn5.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // circleBttn
            // 
            this.circleBttn.DropDownItems.Add(this.circleBtn21);
            this.circleBttn.DropDownItems.Add(this.CircleBtn22);
            this.circleBttn.Image = global::WarCad.Properties.Resources.IconCircle;
            this.circleBttn.LargeImage = global::WarCad.Properties.Resources.IconCircle;
            this.circleBttn.Name = "circleBttn";
            this.circleBttn.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBttn.SmallImage")));
            this.circleBttn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.circleBttn.Text = "Circle";
            // 
            // circleBtn21
            // 
            this.circleBtn21.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn21.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn21.Image")));
            this.circleBtn21.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.LargeImage")));
            this.circleBtn21.Name = "circleBtn21";
            this.circleBtn21.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.SmallImage")));
            this.circleBtn21.Text = "Center, Radius";
            this.circleBtn21.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // CircleBtn22
            // 
            this.CircleBtn22.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.CircleBtn22.Image = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.Image")));
            this.CircleBtn22.LargeImage = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.LargeImage")));
            this.CircleBtn22.Name = "CircleBtn22";
            this.CircleBtn22.SmallImage = ((System.Drawing.Image)(resources.GetObject("CircleBtn22.SmallImage")));
            this.CircleBtn22.Text = "3-poins";
            this.CircleBtn22.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // ellipseBttn
            // 
            this.ellipseBttn.DropDownItems.Add(this.ellipseBtn31);
            this.ellipseBttn.Image = global::WarCad.Properties.Resources.IconEllipse;
            this.ellipseBttn.LargeImage = global::WarCad.Properties.Resources.IconEllipse;
            this.ellipseBttn.Name = "ellipseBttn";
            this.ellipseBttn.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBttn.SmallImage")));
            this.ellipseBttn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.ellipseBttn.Text = "Ellipse";
            // 
            // ellipseBtn31
            // 
            this.ellipseBtn31.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ellipseBtn31.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.Image")));
            this.ellipseBtn31.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.LargeImage")));
            this.ellipseBtn31.Name = "ellipseBtn31";
            this.ellipseBtn31.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.SmallImage")));
            this.ellipseBtn31.Text = "Full Ellipse";
            this.ellipseBtn31.Click += new System.EventHandler(this.EllipseBtn_Click);
            // 
            // lineBttn
            // 
            this.lineBttn.Image = global::WarCad.Properties.Resources.IconLine;
            this.lineBttn.LargeImage = global::WarCad.Properties.Resources.IconLine;
            this.lineBttn.Name = "lineBttn";
            this.lineBttn.SmallImage = ((System.Drawing.Image)(resources.GetObject("lineBttn.SmallImage")));
            this.lineBttn.Text = "Line";
            this.lineBttn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // poliLineBttn
            // 
            this.poliLineBttn.Image = global::WarCad.Properties.Resources.IconPoliLine;
            this.poliLineBttn.LargeImage = global::WarCad.Properties.Resources.IconPoliLine;
            this.poliLineBttn.Name = "poliLineBttn";
            this.poliLineBttn.SmallImage = ((System.Drawing.Image)(resources.GetObject("poliLineBttn.SmallImage")));
            this.poliLineBttn.Text = "PoliLine";
            this.poliLineBttn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // poligonBtn
            // 
            this.poligonBtn.Image = global::WarCad.Properties.Resources.IconPoligon;
            this.poligonBtn.LargeImage = global::WarCad.Properties.Resources.IconPoligon;
            this.poligonBtn.Name = "poligonBtn";
            this.poligonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("poligonBtn.SmallImage")));
            this.poligonBtn.Text = "Poligon";
            this.poligonBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // pointBttn
            // 
            this.pointBttn.Image = global::WarCad.Properties.Resources.IconPoint;
            this.pointBttn.LargeImage = global::WarCad.Properties.Resources.IconPoint;
            this.pointBttn.Name = "pointBttn";
            this.pointBttn.SmallImage = ((System.Drawing.Image)(resources.GetObject("pointBttn.SmallImage")));
            this.pointBttn.Text = "Point";
            this.pointBttn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.Image = global::WarCad.Properties.Resources.IconRectangle;
            this.rectangleBtn.LargeImage = global::WarCad.Properties.Resources.IconRectangle;
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("rectangleBtn.SmallImage")));
            this.rectangleBtn.Text = "Rectangle";
            this.rectangleBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // drawing
            // 
            this.drawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawing.BackColor = System.Drawing.SystemColors.Window;
            this.drawing.ContextMenuStrip = this.popup;
            this.drawing.Location = new System.Drawing.Point(0, 182);
            this.drawing.Margin = new System.Windows.Forms.Padding(4);
            this.drawing.MaximumSize = new System.Drawing.Size(1150, 420);
            this.drawing.Name = "drawing";
            this.drawing.Size = new System.Drawing.Size(1150, 420);
            this.drawing.TabIndex = 0;
            this.drawing.TabStop = false;
            this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
            this.drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseDown);
            this.drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseMove);
            // 
            // stripStatus
            // 
            this.stripStatus.AutoSize = false;
            this.stripStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripStatus.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate,
            this.screen});
            this.stripStatus.Location = new System.Drawing.Point(0, 654);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(1204, 35);
            this.stripStatus.TabIndex = 12;
            this.stripStatus.Text = "0.000, 0.000, 0.000";
            // 
            // coordinate
            // 
            this.coordinate.AutoSize = false;
            this.coordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.coordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(250, 30);
            this.coordinate.Text = "0.000, 0.000, 0.000";
            // 
            // screen
            // 
            this.screen.AutoSize = false;
            this.screen.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.screen.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(200, 30);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(1187, 182);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 420);
            this.vScrollBar.TabIndex = 13;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(0, 637);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(1150, 17);
            this.hScrollBar.TabIndex = 14;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // arcBttn6
            // 
            this.arcBttn6.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn6.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn6.Image")));
            this.arcBttn6.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn6.LargeImage")));
            this.arcBttn6.Name = "arcBttn6";
            this.arcBttn6.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn6.SmallImage")));
            this.arcBttn6.Text = "Start, End, Angle";
            this.arcBttn6.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBttn7
            // 
            this.arcBttn7.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBttn7.Image = ((System.Drawing.Image)(resources.GetObject("arcBttn7.Image")));
            this.arcBttn7.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBttn7.LargeImage")));
            this.arcBttn7.Name = "arcBttn7";
            this.arcBttn7.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBttn7.SmallImage")));
            this.arcBttn7.Text = "Start, Center, Length";
            this.arcBttn7.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 689);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.drawing);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphicsForm";
            this.Text = "Form1";
            this.popup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).EndInit();
            this.stripStatus.ResumeLayout(false);
            this.stripStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawing;
        private System.Windows.Forms.ContextMenuStrip popup;
        private System.Windows.Forms.ToolStripMenuItem CancelBtn;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab drawTab;
        private System.Windows.Forms.RibbonPanel drawPanel;
        private System.Windows.Forms.RibbonButton arcBtn;
        private System.Windows.Forms.RibbonButton arcBttn1;
        private System.Windows.Forms.RibbonButton circleBttn;
        private System.Windows.Forms.RibbonButton circleBtn21;
        private System.Windows.Forms.RibbonButton CircleBtn22;
        private System.Windows.Forms.RibbonButton ellipseBttn;
        private System.Windows.Forms.RibbonButton lineBttn;
        private System.Windows.Forms.RibbonButton poliLineBttn;
        private System.Windows.Forms.RibbonButton poligonBtn;
        private System.Windows.Forms.RibbonButton pointBttn;
        private System.Windows.Forms.RibbonButton rectangleBtn;
        private System.Windows.Forms.RibbonButton ellipseBtn31;
        private System.Windows.Forms.StatusStrip stripStatus;
        private System.Windows.Forms.ToolStripStatusLabel coordinate;
        private System.Windows.Forms.ToolStripStatusLabel screen;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ToolStripMenuItem CloseBoundary;
        private System.Windows.Forms.RibbonButton arcBttn2;
        private System.Windows.Forms.RibbonButton arcBttn3;
        private System.Windows.Forms.RibbonButton arcBttn4;
        private System.Windows.Forms.RibbonButton arcBttn5;
        private System.Windows.Forms.RibbonButton arcBttn6;
        private System.Windows.Forms.RibbonButton arcBttn7;
    }
}

