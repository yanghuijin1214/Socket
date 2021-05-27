using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e){
            string ip = textBox1.Text;
            string port = textBox2.Text;
            //소켓 객체 생성
            try{
                client = new TcpClient();
                client.Connect(ip, int.Parse(port));
                button1.Enabled = false;
            }
            catch(SocketException){
                button1.Enabled = true;
                //textBox3.Text += "connect error";
                listBox1.Items.Add("connect error");
            }
            catch (Exception)
            {
                button1.Enabled = true;
                listBox1.Items.Add("connect error");
            }
            stream = client.GetStream();
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            listBox1.Items.Add(responseData);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
            button1.Enabled = true;
            listBox1.Items.Add("Disconnect");
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
            button1.Enabled = true;
            listBox1.Items.Add("Disconnect");
        }
    }
}
