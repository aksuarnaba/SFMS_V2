namespace SFMS.MAUI.Components.Branding;

public enum BrandLogoVariant
{
    Full,
    Compact,
    IconOnly
}

public enum BrandLogoTheme
{
    Light,
    Dark
}

public partial class BrandLogo : ContentView
{
    public static readonly BindableProperty VariantProperty =
        BindableProperty.Create(
            nameof(Variant),
            typeof(BrandLogoVariant),
            typeof(BrandLogo),
            BrandLogoVariant.Full,
            propertyChanged: OnAppearanceChanged);

    public static readonly BindableProperty ThemeProperty =
        BindableProperty.Create(
            nameof(Theme),
            typeof(BrandLogoTheme),
            typeof(BrandLogo),
            BrandLogoTheme.Light,
            propertyChanged: OnAppearanceChanged);

    public BrandLogoVariant Variant
    {
        get => (BrandLogoVariant)GetValue(VariantProperty);
        set => SetValue(VariantProperty, value);
    }

    public BrandLogoTheme Theme
    {
        get => (BrandLogoTheme)GetValue(ThemeProperty);
        set => SetValue(ThemeProperty, value);
    }

    public BrandLogo()
    {
        InitializeComponent();

        UpdateAppearance();
    }

    private static void OnAppearanceChanged(
        BindableObject bindable,
        object _,
        object __)
    {
        if (bindable is BrandLogo logo)
        {
            logo.UpdateAppearance();
        }
    }

    private void UpdateAppearance()
    {
        UpdateVariant();
        UpdateTheme();
    }

    private void UpdateVariant()
    {
        switch (Variant)
        {
            case BrandLogoVariant.Full:

                BrandText.IsVisible = true;
                Subtitle.IsVisible = true;
                break;

            case BrandLogoVariant.Compact:

                BrandText.IsVisible = true;
                Subtitle.IsVisible = false;
                break;

            case BrandLogoVariant.IconOnly:

                BrandText.IsVisible = false;
                break;
        }
    }

    private void UpdateTheme()
    {
        if (Theme == BrandLogoTheme.Dark)
        {
            Wordmark.TextColor =
                Colors.White;

            Subtitle.TextColor =
                Color.FromArgb("#EDF3FF");

            BottomLayer.BackgroundColor =
                Colors.White;

            LeftFoot.BackgroundColor =
                Colors.White;

            RightFoot.BackgroundColor =
                Colors.White;

            return;
        }

        Wordmark.TextColor =
            GetColor("BrandNavy");

        Subtitle.TextColor =
            GetColor("TextSecondary");

        BottomLayer.BackgroundColor =
            GetColor("BrandNavy");

        LeftFoot.BackgroundColor =
            GetColor("BrandNavy");

        RightFoot.BackgroundColor =
            GetColor("BrandNavy");
    }

    private static Color GetColor(
        string resourceKey)
    {
        if (Application.Current?.Resources.TryGetValue(
                resourceKey,
                out var value) == true &&
            value is Color color)
        {
            return color;
        }

        return Colors.Transparent;
    }
}