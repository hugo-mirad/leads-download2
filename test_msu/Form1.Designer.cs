namespace test_msu
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbState_old = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbSites = new System.Windows.Forms.ComboBox();
            this.clazcities = new System.Windows.Forms.ComboBox();
            this.Navigate = new System.Windows.Forms.Label();
            this.btn_End = new System.Windows.Forms.Button();
            this.Del_History = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 91);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = "";
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox1.Location = new System.Drawing.Point(12, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "";
            this.textBox1.Visible = false;
            // 
            // cmbState_old
            // 
            this.cmbState_old.FormattingEnabled = true;
            this.cmbState_old.Items.AddRange(new object[] {
            "antique-classic-cars",
            "convertibles",
            "coupes",
            "hatchbacks",
            "hybrids",
            "minivans",
            "suvs",
            "sedans",
            "station-wagons",
            "trucks",
            "vans"});
            this.cmbState_old.Location = new System.Drawing.Point(9, 39);
            this.cmbState_old.Name = "cmbState_old";
            this.cmbState_old.Size = new System.Drawing.Size(159, 21);
            this.cmbState_old.TabIndex = 6;
            this.cmbState_old.Visible = false;
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(10, 39);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(158, 21);
            this.cmbState.TabIndex = 7;
            this.cmbState.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bakersfield",
            "Chico",
            "Fresno",
            "Humboldt County",
            "Imperial County",
            "Inland Empire",
            "Long Beach",
            "Los Angeles",
            "Mendocino",
            "Merced",
            "Modesto",
            "Monterey",
            "North Bay",
            "O.C.",
            "Oakland",
            "Palm Springs",
            "Palmdale",
            "Redding",
            "Sacramento",
            "San Diego",
            "San Fernando Valley",
            "San Francisco",
            "San Gabriel Valley",
            "San Jose",
            "San Luis Obispo",
            "San Mateo",
            "Santa Barbara",
            "Santa Cruz",
            "Santa Maria",
            "Siskiyou",
            "Stockton",
            "Susanville",
            "Ventura",
            "Visalia",
            "Abilene",
            "Amarillo",
            "Austin",
            "Beaumont",
            "Brownsville",
            "College Station",
            "Corpus Christi",
            "Dallas",
            "Del Rio",
            "Denton",
            "El Paso",
            "Fort Worth",
            "Galveston",
            "Houston",
            "Huntsville",
            "Killeen",
            "Laredo",
            "Lubbock",
            "Mcallen",
            "mid cities",
            "Odessa",
            "San Antonio",
            "San Marcos",
            "Texarkana",
            "Texoma",
            "Tyler",
            "Victoria",
            "Waco",
            "Wichita Falls",
            "Daytona",
            "Fort Myers",
            "Ft Lauderdale",
            "Gainesville",
            "Jacksonville",
            "Keys",
            "Lakeland",
            "Miami",
            "Ocala",
            "Okaloosa",
            "Orlando",
            "Panama City",
            "Pensacola",
            "Sarasota",
            "Space Coast",
            "St. Augustine",
            "Tallahassee",
            "Tampa",
            "Treasure Coast",
            "West Palm Beach"});
            this.comboBox1.Location = new System.Drawing.Point(9, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Visible = false;
            // 
            // cmbSites
            // 
            this.cmbSites.FormattingEnabled = true;
            this.cmbSites.Items.AddRange(new object[] {
            "oodle",
            "ebay",
            "global",
            "backpage",
            "locanto",
            "claz"});
            this.cmbSites.Location = new System.Drawing.Point(9, 12);
            this.cmbSites.Name = "cmbSites";
            this.cmbSites.Size = new System.Drawing.Size(159, 21);
            this.cmbSites.TabIndex = 9;
            this.cmbSites.SelectedIndexChanged += new System.EventHandler(this.cmbSites_SelectedIndexChanged);
            // 
            // clazcities
            // 
            this.clazcities.FormattingEnabled = true;
            this.clazcities.Items.AddRange(new object[] {
            "Abilene",
            "Albany",
            "Albuquerque",
            "Allentown",
            "Altoona",
            "Amarillo",
            "Ames",
            "Anchorage",
            "Annapolis",
            "Annarbor",
            "appleton",
            "Asheville",
            "Ashtabula",
            "Atlanta",
            "Auburn",
            "Augusta",
            "Austin",
            "Bakersfield",
            "Baltimore",
            "Batonrouge",
            "Battlecreek",
            "Beaumont",
            "Bellingham",
            "Bemidji",
            "Bend",
            "Bigbend",
            "Billings",
            "Binghamton",
            "Bismarck",
            "Blacksburg",
            "Bloomington",
            "Boise",
            "Boone",
            "Boston",
            "Boulder",
            "Bozeman",
            "Brainerd",
            "Brownsville",
            "Brunswick",
            "Buffalo",
            "burlington",
            "Butte",
            "Carbondale",
            "Cedarrapids",
            "Chambersburg",
            "Charleston",
            "Charlotte",
            "Charlottesville",
            "Chattanooga",
            "Chautauqua",
            "Chicago",
            "Chico",
            "Chillicothe",
            "Cincinnati",
            "Clarksville",
            "Cleveland",
            "Clovis",
            "CollegeStation",
            "Columbia",
            "Columbus",
            "Cookeville",
            "CorpusChristi",
            "Corvallis",
            "Dallas",
            "Danville",
            "Dayton",
            "Daytona",
            "Decatur",
            "delaware",
            "DelRio",
            "Denton",
            "Denver",
            "Desmoines",
            "Detroit",
            "Dothan",
            "Dubuque",
            "Duluth",
            "Easttexas",
            "eauclaire",
            "Elko",
            "Elmira",
            "ElPaso",
            "Enid",
            "Erie",
            "Eugene",
            "Evansville",
            "Fairbanks",
            "Fargo",
            "Fargo",
            "Farmington",
            "Fayetteville",
            "Flagstaff",
            "Flint",
            "Fortcollins",
            "Fortdodge",
            "fortlauderdale",
            "FortMyers",
            "Fortsmith",
            "Fortwayne",
            "FortWorth",
            "Frederick",
            "Fredericksburg",
            "Fresno",
            "Gadsden",
            "Gainesville",
            "Galveston",
            "Glensfalls",
            "Grandforks",
            "grandisland",
            "Grandrapids",
            "Greatfalls",
            "Greenbay",
            "Greensboro",
            "Greenville",
            "Gulfport",
            "Hanford",
            "Harrisburg",
            "Harrisonburg",
            "Hartford",
            "Hattiesburg",
            "Helena",
            "Hickory",
            "Hiltonhead",
            "Holland",
            "Houma",
            "Houston",
            "Humboldt",
            "Huntington",
            "Huntsville",
            "Imperial",
            "Indianapolis",
            "Iowacity",
            "Ithaca",
            "Jackson",
            "Jacksonville",
            "Janesville",
            "Jerseyshore",
            "Jonesboro",
            "Joplin",
            "Juneau",
            "Kalamazoo",
            "Kalispell",
            "Kansascity",
            "Kenai",
            "Keys",
            "Killeen",
            "Kirksville",
            "Klamath",
            "Knoxville",
            "Kokomo",
            "Lacrosse",
            "Lafayette",
            "Lakecharles",
            "Lakecity",
            "Lakeland",
            "Lancaster",
            "Laredo",
            "Lasalle",
            "Lascruces",
            "Lasvegas",
            "Lawrence",
            "lawton",
            "Lewiston",
            "Lexington",
            "Lincoln",
            "Littlerock",
            "Logan",
            "LongBeach",
            "Longisland",
            "LosAngeles",
            "Louisville",
            "Lubbock",
            "Lynchburg",
            "Macon",
            "Madison",
            "maine",
            "Mankato",
            "Mansfield",
            "Marshall",
            "Martinsburg",
            "Masoncity",
            "Mattoon",
            "Mcallen",
            "Meadville",
            "Medford",
            "Memphis",
            "Mendocino",
            "Merced",
            "Meridian",
            "Miami",
            "Milwaukee",
            "Minneapolis",
            "Missoula",
            "Mobile",
            "Modesto",
            "Mohave",
            "Monroe",
            "Montana",
            "Monterey",
            "Montgomery",
            "Morgantown",
            "Moseslake",
            "muncie",
            "Muskegon",
            "Myrtlebeach",
            "Nacogdoches",
            "Nashville",
            "Natchez",
            "Newhaven",
            "Newlondon",
            "Neworleans",
            "Newyork",
            "nh",
            "Norfolk",
            "NorthBay",
            "northplatte",
            "Oakland",
            "Ocala",
            "Odessa",
            "Ogden",
            "Okaloosa",
            "Oklahomacity",
            "Olympic",
            "Omaha",
            "Oneonta",
            "Onslow",
            "Orlando",
            "Ottumwa",
            "Owensboro",
            "Palmdale",
            "PalmSprings",
            "PanamaCity",
            "Parkersburg",
            "Pensacola",
            "Peoria",
            "Philadelphia",
            "Phoenix",
            "Pittsburgh",
            "Plattsburgh",
            "Porthuron",
            "Portland",
            "Potsdam",
            "Prescott",
            "providence",
            "Provo",
            "Pueblo",
            "Pullman",
            "Quincy",
            "Racine",
            "Raleigh",
            "Rapidcity",
            "Reading",
            "Reno",
            "Richmond",
            "Roanoke",
            "Rochester",
            "Rockford",
            "Roseburg",
            "Roswell",
            "Sacramento",
            "Saginaw",
            "Salem",
            "Salina",
            "Saltlakecity",
            "Sanangelo",
            "SanAntonio",
            "SanDiego",
            "Sandiego",
            "Sandusky",
            "SanFrancisco",
            "SanJose",
            "SanLuisObispo",
            "SanMarcos",
            "Sanmarcos",
            "SanMateo",
            "SantaBarbara",
            "SantaCruz",
            "Santafe",
            "SantaMaria",
            "Santamaria",
            "Sarasota",
            "Savannah",
            "scottsbluff",
            "Scranton",
            "Sd",
            "Seattle",
            "Sheboygan",
            "Shoals",
            "Showlow",
            "Shreveport",
            "Sierravista",
            "Siouxcity",
            "Siouxfalls",
            "Skagit",
            "Slo",
            "Southbend",
            "Spokane",
            "Springfield",
            "St.Augustine",
            "Statesboro",
            "Staugustine",
            "Stcloud",
            "Stgeorge",
            "Stillwater",
            "Stjoseph",
            "Stlouis",
            "Stockton",
            "Susanville",
            "Syracuse",
            "Tallahassee",
            "Tampa",
            "terrehaute",
            "Texarkana",
            "tippecanoe",
            "Toledo",
            "Topeka",
            "Treasure",
            "Tricities",
            "Tucson",
            "Tulsa",
            "Tuscaloosa",
            "Tuscarawas",
            "Twinfalls",
            "Tyler",
            "Utica",
            "Valdosta",
            "Ventura",
            "Victoria",
            "Visalia",
            "Waco",
            "Washingtondc",
            "Waterloo",
            "Watertown",
            "Wausau",
            "Wenatchee",
            "WestPalmBeach",
            "Westslope",
            "Wheeling",
            "Wichita",
            "WichitaFalls",
            "Williamsport",
            "Wilmington",
            "Winchester",
            "Winstonsalem",
            "Worcester",
            "Wv",
            "wyoming",
            "Yakima",
            "York",
            "Youngstown",
            "Yuma",
            "Zanesville"});
            this.clazcities.Location = new System.Drawing.Point(10, 39);
            this.clazcities.Name = "clazcities";
            this.clazcities.Size = new System.Drawing.Size(159, 21);
            this.clazcities.TabIndex = 10;
            this.clazcities.Visible = false;
            // 
            // Navigate
            // 
            this.Navigate.AutoSize = true;
            this.Navigate.Location = new System.Drawing.Point(12, 135);
            this.Navigate.Name = "Navigate";
            this.Navigate.Size = new System.Drawing.Size(13, 13);
            this.Navigate.TabIndex = 11;
            this.Navigate.Text = "0";
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(99, 92);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(66, 23);
            this.btn_End.TabIndex = 12;
            this.btn_End.Text = "End";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // Del_History
            // 
            this.Del_History.Location = new System.Drawing.Point(40, 149);
            this.Del_History.Name = "Del_History";
            this.Del_History.Size = new System.Drawing.Size(94, 23);
            this.Del_History.TabIndex = 38;
            this.Del_History.Text = "Del_History";
            this.Del_History.UseVisualStyleBackColor = true;
            this.Del_History.Click += new System.EventHandler(this.Del_History_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 176);
            this.Controls.Add(this.Del_History);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.Navigate);
            this.Controls.Add(this.cmbSites);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.clazcities);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbState_old);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbState_old;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbSites;
        private System.Windows.Forms.ComboBox clazcities;
        private System.Windows.Forms.Label Navigate;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.Button Del_History;
    }
}

