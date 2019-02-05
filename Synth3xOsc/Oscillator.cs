using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Synth3xOsc
{
    public class Oscillator : GroupBox
    {
        public Oscillator()
        {
            this.BackColor = Color.Bisque;

            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                BackColor = Color.Yellow
                });

            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(65, 15),
                Text = "Square",
                BackColor = Color.Beige

            });

            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(120, 15),
                Text = "Saw",
                BackColor = Color.Beige
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(10, 50),
                Text = "Triangle",
                BackColor = Color.Beige
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise",
                BackColor = Color.Beige
            });

            foreach(Control control in this.Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsoft Sans Serif", 6.75f);
                control.Click += WaveButton_Click;
            }

            frequency = new TrackBar()
            {
                Name = "Frequency",
                Location = new Point(90, 100),
                Size = new Size(180, 40),
                Minimum = 50,
                Maximum = 2000,
                Value = 50
            };

            volume = new TrackBar()
            {
                Name = "Volume",
                Location = new Point(90, 150),
                Size = new Size(180, 40),
                Minimum = 0,
                Maximum = 100,
                Value = 100
            };

            this.Controls.Add(new CheckBox()
            {
                Name = "OscillatorOn",
                Location = new Point(210, 10),
                Size = new Size(40, 30),
                Text = "On",
                Checked = true
            });

            this.Controls.Add(frequency);

            Lfreq = new Label()
            {
                Name = "Frequency_lvl",
                Location = new Point(280, 100),
                Text = frequency.Value.ToString()
            };

            this.Controls.Add(Lfreq);

            Label MainFreq = new Label()
            {
                Location = new Point(35, 100),
                Text = "frequency"
            };
            this.Controls.Add(MainFreq);


            frequency.ValueChanged +=
        new EventHandler(FrequencyValueChanged);

            this.Controls.Add(volume);

            Lvol = new Label()
            {
                Name = "Volume_lvl",
                Location = new Point(280, 150),
                Text = volume.Value.ToString()
            };

            this.Controls.Add(Lvol);

            Label Mainvol = new Label()
            {
                Location = new Point(35, 150),
                Text = "volume"
            };
            this.Controls.Add(Mainvol);

            volume.ValueChanged += new EventHandler(VolumeValueChanged);

        }

        public WaveForm WaveForm { get; private set; }

        public bool On { get { return ((CheckBox)this.Controls["OscillatorOn"]).Checked; } }

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);

            foreach (Button otherButtons in this.Controls.OfType<Button>())
            {
                otherButtons.BackColor = Color.Beige;
            }

            button.BackColor = Color.Yellow;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }


        public void FrequencyValueChanged(object sender, EventArgs e)
        {
            Lfreq.Text = frequency.Value.ToString();
        }

        public void VolumeValueChanged(object sender, EventArgs e)
        {
            Lvol.Text = volume.Value.ToString();
        }

        private Label Lfreq;
        private Label Lvol;
        public TrackBar frequency;
        public TrackBar volume;

    }
}
