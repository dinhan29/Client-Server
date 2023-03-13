using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        IPEndPoint IP;
        Socket client;

        // Connect server
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);

            }
            catch
            {
                MessageBox.Show("Can't connect", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }

        // Close connect
        void Close()
        {
            client.Send(Serialize("----------------Im out----------------"));
            client.Close();
        }

        // Send message
        void Send()
        {
            if (txbMessage.Text != string.Empty)
            {
                client.Send(Serialize(txbMessage.Text));
            }
        }

        // Receive messgae
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new Byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }


        }

        // Add message to list view
        void AddMessage(string s)
        {
            if (s != null)
            {
                lsvMessage.Items.Add(new ListViewItem() { Text = s });
                txbMessage.Clear();
            }
        }

        // Phan manh
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        // Gom phan manh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        // Close connect when close form
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txbMessage.Text != string.Empty)
            {
                Send();
                AddMessage("Me: " + txbMessage.Text);
            }
        }

        //Socket 
        //Ip
    }
}