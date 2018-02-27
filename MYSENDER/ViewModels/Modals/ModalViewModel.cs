using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYSENDER.ViewModels;

namespace MYSENDER.ViewModels.Modals
{
    public enum ModalType
    {
        Add, Update, Delete, SetTemplate, Display
    }

    public class ModalViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string FormId { get; set; }
        public List<ButtonViewModel> Buttons { get; set; }
        public bool Required { get; set; } = true;
        public dynamic Model { get; set; }

        public T GetModel<T>()
        {
            return (T)Model;
        }

        public class ButtonViewModel
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
