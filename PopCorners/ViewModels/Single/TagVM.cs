using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PopCorners.Helpers;
using PopCorners.Models;
using PopCorners.Models.DTOs;
using PopCorners.Models.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace PopCorners.ViewModels.Single
{
    public class TagVM : BaseSingleViewModel<TagService, TagDTO, Tag>
    {
        public int TagId
        {
            get => Model.TagId;
            set
            {
                if (Model.TagId != value)
                {
                    Model.TagId = value;
                    OnPropertyChanged(() => TagId);
                }
            }
        }
        public string TagName
        {
            get => Model.TagName;
            set
            {
                if (Model.TagName != value)
                {
                    Model.TagName = value;
                    OnPropertyChanged(() => TagName);
                }
            }
        }
        public DateTime CreationDate
        {
            get => Model.CreationDate;
            set
            {
                if (Model.CreationDate != value)
                {
                    Model.CreationDate = value;
                    OnPropertyChanged(() => CreationDate);
                }
            }
        }
        public DateTime? EditionDate
        {
            get => Model.EditionDate;
            set
            {
                if (Model.EditionDate != value)
                {
                    Model.EditionDate = value;
                    OnPropertyChanged(() => EditionDate);
                }
            }
        }
        public ICommand ValidateCommand { get; set; }
        public bool IsExisting { get; set; }
        public TagVM() : base("Tag")
        {
            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = false;
        }
        public TagVM(TagDTO selected) : base(selected.TagName ?? "Tag")
        {
            TagId = selected.TagId;
            TagName = selected.TagName ?? "";
            CreationDate = selected.CreationDate;
            EditionDate = selected.EditionDate;

            ValidateCommand = new BaseCommand(() => ValidateAndSaveData());
            IsExisting = true;
        }
        protected override void Duplicate()
        {
            TagDTO original = Service.GetDTO(Model);
            TagDTO copy = new TagDTO()
            {
                TagId = 0,
                TagName = "Copy_" + original.TagName,
                CreationDate = DateTime.Now,
                EditionDate = null
            };
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<TagDTO?>(copy));
        }
        private void ValidateAndSaveData()
        {
            if (Model != null)
            {
                if (string.IsNullOrEmpty(Model.TagName))
                {
                    Debug.WriteLine("[!] Nazwa musi być niepustym typem string");
                    return; // imię musi być niepustym stringiem
                }

                Debug.WriteLine("Zapisano: " + Model.TagName);

                if (IsExisting) Update();
                else Save();
            }
        }
    }
}
