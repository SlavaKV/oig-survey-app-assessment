using Microsoft.AspNetCore.Components;
using Survey.WebUI.Data.Questionnaires;

namespace Survey.WebUI.Pages.Questionnaires.List
{
    public partial class List
    {
        private QuestionnaireListVM _model = new();
        private List<QuestionnaireListItemVM> _listItems;

        private string _search;
        private int? _sortIndex = 3; // TODO: Take default value from Application

        [Inject] private IQuestionnaireService QuestionnaireService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Refresh();
        }

        private async Task Search()
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            _model = await QuestionnaireService.GetQuestionnairesAsync(_search, _sortIndex);
            _listItems = _model.Questionnaires;
        }
    }
}
