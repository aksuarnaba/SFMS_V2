namespace SFMS.MAUI.Components.Layout;

public partial class AppTopBar : ContentView
{
    public static readonly BindableProperty PageTitleProperty =
        BindableProperty.Create(
            nameof(PageTitle),
            typeof(string),
            typeof(AppTopBar),
            "Dashboard");

    public static readonly BindableProperty SiteDescriptionProperty =
        BindableProperty.Create(
            nameof(SiteDescription),
            typeof(string),
            typeof(AppTopBar),
            string.Empty);

    public static readonly BindableProperty UserNameProperty =
        BindableProperty.Create(
            nameof(UserName),
            typeof(string),
            typeof(AppTopBar),
            string.Empty);

    public static readonly BindableProperty UserRoleProperty =
        BindableProperty.Create(
            nameof(UserRole),
            typeof(string),
            typeof(AppTopBar),
            string.Empty);

    public static readonly BindableProperty UserInitialsProperty =
        BindableProperty.Create(
            nameof(UserInitials),
            typeof(string),
            typeof(AppTopBar),
            string.Empty);

    public string PageTitle
    {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }

    public string SiteDescription
    {
        get => (string)GetValue(SiteDescriptionProperty);
        set => SetValue(SiteDescriptionProperty, value);
    }

    public string UserName
    {
        get => (string)GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    public string UserRole
    {
        get => (string)GetValue(UserRoleProperty);
        set => SetValue(UserRoleProperty, value);
    }

    public string UserInitials
    {
        get => (string)GetValue(UserInitialsProperty);
        set => SetValue(UserInitialsProperty, value);
    }

    public AppTopBar()
    {
        InitializeComponent();
    }
}