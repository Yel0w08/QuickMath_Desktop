using QuickMath.Domain;
using QuickMath.Services;

namespace QuickMath;

/// <summary>
/// Shop dialog that displays SQL-backed catalog items and delegates checkout to the service layer.
/// </summary>
public partial class Shop : Form
{
    private readonly ShopService _shopService;
    private readonly UserService _userService;
    private readonly UserSession _userSession;
    private readonly CheckBox[] _shopItemCheckboxes;
    private IReadOnlyList<ShopCatalogItem> _currentItems = Array.Empty<ShopCatalogItem>();

    public Shop(ShopService shopService, UserService userService, UserSession userSession)
    {
        _shopService = shopService;
        _userService = userService;
        _userSession = userSession;

        InitializeComponent();

        _shopItemCheckboxes = [shopItem1, shopItem2, shopItem3, shopItem4, shopItem5];
        Shop_Select_Category.SelectedIndex = 0;
        LoadCategory(ShopCategory.Difficulty);
    }

    private void Shop_Select_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        var category = Shop_Select_Category.SelectedItem?.ToString() == "Stars"
            ? ShopCategory.Stars
            : ShopCategory.Difficulty;

        LoadCategory(category);
    }

    private void LoadCategory(ShopCategory category)
    {
        // The shop never caches business data outside the dialog lifetime: each
        // category load comes from SQL through the service layer.
        _currentItems = _shopService.GetCatalog(_userSession.CurrentUserId, category);

        for (var index = 0; index < _shopItemCheckboxes.Length; index++)
        {
            var checkBox = _shopItemCheckboxes[index];
            if (index >= _currentItems.Count)
            {
                checkBox.Visible = false;
                checkBox.Checked = false;
                checkBox.Text = string.Empty;
                continue;
            }

            var item = _currentItems[index];
            checkBox.Visible = true;
            checkBox.Checked = false;
            checkBox.Enabled = item.IsRepeatable || !item.IsOwned;
            checkBox.ForeColor = item.IsOwned && !item.IsRepeatable ? Color.Green : Color.Black;
            checkBox.Text = item.IsOwned && !item.IsRepeatable
                ? $"{item.DisplayName} (Owned)"
                : item.DisplayName;
        }

        if (_currentItems.Count == 0)
        {
            MessageBox.Show("No items are currently available in this category for your XP level.");
        }

        UpdateCart();
        ReloadGui();
    }

    private void UpdateCart()
    {
        CartListBox.Items.Clear();
        decimal total = 0m;

        // The UI cart is only a transient projection; prices are always revalidated
        // in the repository before a purchase is committed.
        for (var index = 0; index < _currentItems.Count && index < _shopItemCheckboxes.Length; index++)
        {
            if (!_shopItemCheckboxes[index].Checked)
            {
                continue;
            }

            var item = _currentItems[index];
            CartListBox.Items.Add($"{item.DisplayName} [{item.PriceCoins:0.##}]");
            total += item.PriceCoins;
        }

        Total_Shop_Label.Text = $"Total = {total:0.##} coins";
    }

    private void ReloadGui()
    {
        // Refresh from SQL after a purchase so the visible balance always matches
        // the persisted value used by the repositories.
        var user = _userService.RefreshCurrentUser();
        MoneyInAccountLabel.Text = $"Money = {user.Coins:0.##} coins";
    }

    private void Shop_buy_button(object sender, EventArgs e)
    {
        try
        {
            var selectedIds = _currentItems
                .Select((item, index) => new { item.ShopItemId, Selected = _shopItemCheckboxes[index].Checked })
                .Where(static selection => selection.Selected)
                .Select(static selection => selection.ShopItemId)
                .ToArray();

            var result = _shopService.Purchase(_userSession.CurrentUserId, selectedIds);
            MessageBox.Show(result.Message, "Shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCategory(Shop_Select_Category.SelectedItem?.ToString() == "Stars" ? ShopCategory.Stars : ShopCategory.Difficulty);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message, "Purchase error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void shopItem1_CheckedChanged(object sender, EventArgs e) => UpdateCart();
    private void shopItem2_CheckedChanged(object sender, EventArgs e) => UpdateCart();
    private void shopItem2_CheckedChanged_1(object sender, EventArgs e) => UpdateCart();
    private void shopItem3_CheckedChanged(object sender, EventArgs e) => UpdateCart();
    private void shopItem4_CheckedChanged(object sender, EventArgs e) => UpdateCart();
    private void shopItem5_CheckedChanged(object sender, EventArgs e) => UpdateCart();

    private void CartListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Shop_Load(object sender, EventArgs e)
    {
    }
}
