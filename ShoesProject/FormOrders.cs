using Microsoft.EntityFrameworkCore;
using ShoesProject.Models;
using ShoesProject.Properties;

namespace ShoesProject
{
    public partial class FormOrders : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormOrders(User user, bool guest)
        {
            InitializeComponent();
            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.HeaderText = "Информация о заказе";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colComposition = new DataGridViewTextBoxColumn();
            colComposition.Name = "colComposition";
            colComposition.HeaderText = "Состав заказа";
            colComposition.FillWeight = 30;
            colComposition.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colCost = new DataGridViewTextBoxColumn();
            colCost.Name = "colCost";
            colCost.HeaderText = "Стоимость";
            colCost.FillWeight = 10;
            colCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(new DataGridViewColumn[]
            {
                colInfo, colComposition, colCost
            });

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (var db = new ShopDb2Context())
                {
                    var query = db.Orders
                        .Include(o => o.Status)
                        .Include(o => o.DeliveryPoint)
                        .Include(o => o.User)
                        .Include(o => o.ProductsOrders)
                            .ThenInclude(po => po.Product)
                                .ThenInclude(p => p.Category) 
                        .Include(o => o.ProductsOrders)
                            .ThenInclude(po => po.Product)
                                .ThenInclude(p => p.ProductType)
                        .Where(o => o.IdUser == CurrentUser.Id)
                        .OrderByDescending(o => o.OrderDate)
                        .AsQueryable();
                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear(); 
                    var orders = query.ToList();
                    foreach (var order in orders)
                    {
                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];
                        row.Cells["colInfo"].Value = FormatOrderInfo(order);
                        row.Cells["colComposition"].Value = FormatOrderComposition(order);
                        row.Cells["colCost"].Value = $"{CalculateTotalCost(order):C}";
                        ApplyRowStyles(row, order);
                    }
                    dgvOrders.ResumeLayout();
                    dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string FormatOrderInfo(Order order)
        {
            return $"Заказ № {order.Id} (Код получения: {order.Code})" + Environment.NewLine
                + $"Дата заказа: {order.OrderDate:dd.MM.yyyy}" + Environment.NewLine
                + $"Дата доставки: {order.DeliveryDate:dd.MM.yyyy}" + Environment.NewLine
                + $"Пункт выдачи: {order.DeliveryPoint.DeliveryAddress}" + Environment.NewLine
                + $"Клиент: {order.User.FullName}" + Environment.NewLine
                + $"Статус: {order.Status.StatusName}";
        }

        private string FormatOrderComposition(Order order)
        {
            if (order.ProductsOrders == null || !order.ProductsOrders.Any())
            {
                return "Нет товаров в заказе";
            }
            var compositionLines = order.ProductsOrders.Select(po =>$"- {po.Product.Category?.CategoryName} {po.Product.ProductType?.ProdType} (Арт. {po.Product.Art}) x {po.Quantity} шт.");
            return string.Join(Environment.NewLine, compositionLines);
        }



        private decimal CalculateTotalCost(Order order)
        {
            if (order.ProductsOrders == null) return 0;
            return order.ProductsOrders.Sum(po =>
            {
                decimal priceWithDiscount = po.Product.Price * (100 - po.Product.Discount) / 100;
                return priceWithDiscount * po.Quantity;
            });
        }

        private void ApplyRowStyles(DataGridViewRow row, Order order)
        {
            if (order.IdStatuses == 3)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else if (order.IdStatuses == 2)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}