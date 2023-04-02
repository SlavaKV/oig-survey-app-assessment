using Microsoft.AspNetCore.Components;
using Survey.WebUI.Data.Questionnaires;

namespace Survey.WebUI.Pages.Questionnaires.Detail
{
    public partial class Detail
    {
        [Parameter] public int? Id { get; set; }

        private QuestionnaireVM _model = new();

        private bool _isAddMode => Id is null;
        private bool _isEditMode => Id is not null;
        private bool _isLoading = true;

        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] private IQuestionnaireService QuestionnaireService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            _isLoading = true;
            if (_isEditMode)
            {
                _model = await QuestionnaireService.GetQuestionnaireByIdAsync(Id.Value);
            }
            _isLoading = false;
        }

        private async Task Submit()
        {
            if (_isAddMode)
            {
                int id = await QuestionnaireService.Create(_model);
            }

            if (_isEditMode)
            {
                await QuestionnaireService.Update(_model);
            }

            Navigation.NavigateTo($"/questionnaires");
        }

        private async Task ChangeStatus()
        {
            if (_isEditMode)
            {
                await QuestionnaireService.ChangeStatus(_model);
            }
            await Refresh();
        }
    }
}
