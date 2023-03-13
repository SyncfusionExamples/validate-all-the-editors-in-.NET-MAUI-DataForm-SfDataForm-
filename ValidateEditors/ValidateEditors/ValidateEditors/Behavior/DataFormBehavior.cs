using Syncfusion.Maui.DataForm;

namespace ValidateEditors
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm dataForm;

        private Button validateButton;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            if (dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemSourceProvider();
                dataForm.RegisterEditor("Country", DataFormEditorType.AutoComplete);
                dataForm.RegisterEditor("City", DataFormEditorType.ComboBox);
            }

            this.validateButton = bindable.FindByName<Button>("validateButton");
            if (this.validateButton != null)
            {
                this.validateButton.Clicked += OnValidateClicked;
            }
        }
        private void OnValidateClicked(object sender, EventArgs e)
        {
            dataForm.Validate();
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.validateButton != null)
            {
                this.validateButton.Clicked -= OnValidateClicked;
            }
        }
    }
}