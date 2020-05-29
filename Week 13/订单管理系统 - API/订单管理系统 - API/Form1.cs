using System;
using System.Windows.Forms;
using OrderDB;

namespace OrderManageSystem
{
    public partial class Form1 : Form
    {
        private OrderService service;
        //private Order CurrentOrder = null;
        string CurrentOrderID = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            service = new OrderService();
            Goods goods = new Goods();

            bs_OrderList.DataSource = service.GetAllOrder();
            dataGridView_OrderList.DataSource = bs_OrderList;

            dataGridView_OrderItem.DataSource = bs_OrderItem;

            comboBox_Goods.DataSource = goods.GoodsList;
            comboBox_Goods.DisplayMember = "name";

            //try
            //{
            //    service.Import();
            //    Console.WriteLine("成功读取了存档数据。");
            //}
            //catch (FileNotFoundException)
            //{
            //    Console.WriteLine("未找到存档数据。");
            //}

            //var o = new Order("xlx");
            //service.AddOrder(o);
            //CurrentOrder = o;
            //dataGridView_OrderList.DataSource = service.OrderList;
            //CurrentOrder.AddItem("电脑", 1);
            //CurrentOrder.AddItem("水杯", 2);

            //bs_OrderList.ResetBindings(false);


            //o = new Order("dzy");
            //service.AddOrder(o);
            //CurrentOrder = o;
            //bs_OrderList.ResetBindings(false);

        }


        private void dataGridView_OrderList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_OrderList.CurrentRow != null)
            {
                CurrentOrderID = dataGridView_OrderList.CurrentRow.Cells[1].Value.ToString();
                
                if (CurrentOrderID != "")
                {
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderItem.ResetBindings(false);
                    tb_Customer.Text = dataGridView_OrderList.CurrentRow.Cells[0].Value.ToString();

                }
            }
                
            
            
        }

        private string product;
        private void dataGridView_OrderItem_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView_OrderItem.CurrentRow!=null)
            {
                product = dataGridView_OrderItem.CurrentRow.Cells[0].Value.ToString();
                comboBox_Goods.SelectedIndex = comboBox_Goods.FindStringExact(product);
                tb_num.Text = dataGridView_OrderItem.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            if (tb_Customer.Text == "")
            {
                tb_Tips.Text = "请输入客户名。";
            }
            else
            {
                try
                {
                    service.AddOrder(tb_Customer.Text);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    tb_Tips.Text = "系统已成功为你创建了新订单。继续添加订单明细吧。";
                    bs_OrderList.ResetBindings(false);
                }
                catch(OrderExistsException ex)
                {
                    tb_Tips.Text = ex.Message;
                }
                
            }

        }

        private void btn_DelOrder_Click(object sender, EventArgs e)
        {
            
            try
            {
                var ID = dataGridView_OrderList.CurrentRow.Cells[1].Value.ToString();
                service.DelOrder(ID);
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            catch
            {
                tb_Tips.Text = "删除订单失败，请重新选择再试。";
            }
        }

        private void btn_AddP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！请先选中订单后再尝试添加订单明细。";
            }
            else
            {
                string pname = comboBox_Goods.Text;
                int pnum = Convert.ToInt32(tb_num.Text);
                try
                {
                    service.AddItem(CurrentOrderID, pname, pnum);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                    
                }
                catch (ItemExistsException)
                {
                    tb_Tips.Text = "添加商品失败，当前商品已存在。如需修改请点击修改按钮。";
                }
                catch (GoodNotExistsException)
                {
                    tb_Tips.Text = "添加商品失败，尝试添加的商品不存在。";
                }

            }
            
        }

        private void btn_MdP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！请先选中订单后再尝试修改订单明细。";
            }
            else
            {
                string pname = comboBox_Goods.Text;
                int pnum = Convert.ToInt32(tb_num.Text);
                try
                {
                    service.ModifyOrder(CurrentOrderID, pname, pnum);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                }
                catch (OrderInvalidException)
                {
                    tb_Tips.Text = "修改订单失败，请检查订单号是否正确。";
                }
                catch (ItemInvalidException)
                {
                    tb_Tips.Text = "修改订单失败，请检查商品名称是否正确。";
                }
            }
            
        }

        private void btn_DelP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！请先选中订单后再尝试删除订单明细。";
            }
            else
            {
                string pname = comboBox_Goods.Text;
                try
                {
                    service.ModifyOrder(CurrentOrderID, pname, 0);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                }
                catch (OrderInvalidException)
                {
                    tb_Tips.Text = "删除订单失败，请检查订单号是否正确。";
                }
                catch (ItemInvalidException)
                {
                    tb_Tips.Text = "删除订单失败，请检查商品名称是否正确。";
                }
            }
        }

        private void btn_QID_Click(object sender, EventArgs e)
        {
            if(tb_Query.Text=="")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var re = service.Query("ID", tb_Query.Text);
                bs_OrderList.DataSource = re;
                bs_OrderList.ResetBindings(false);
            }
            
        }

        private void btn_QPn_Click(object sender, EventArgs e)
        {
            if (tb_Query.Text == "")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var re = service.Query("Product", tb_Query.Text);
                bs_OrderList.DataSource = re;
                bs_OrderList.ResetBindings(false);
            }
        }

        private void btn_QC_Click(object sender, EventArgs e)
        {
            if (tb_Query.Text == "")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var re = service.Query("Customer", tb_Query.Text);
                bs_OrderList.DataSource = re;
                bs_OrderList.ResetBindings(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("ID");
            bs_OrderList.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("Customer");
            bs_OrderList.ResetBindings(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("Price");
            bs_OrderList.ResetBindings(false);
        }

        private void dataGridView_OrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
