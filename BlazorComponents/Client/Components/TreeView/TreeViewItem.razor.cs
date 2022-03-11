using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorComponents.Client.Components.TreeView
{
    public partial class TreeViewItem<T> : ComponentBase
    {
        [CascadingParameter]
        public TreeView<T>? ParentTree { get; set; }

        [Parameter]
        public T? Source { get; set; }

        [Parameter]
        public Func<T, List<T>>? ChildItemSelector { get; set; }

        [Parameter]
        public Func<T, string>? HeaderSelector { get; set; }

        [Parameter]
        public Func<T, string>? ItemIconCssSelector { get; set; }

        [Parameter]
        public string Style { get; set; } = "";

        [Parameter]
        public int IndentLevel { get; set; }

        [Parameter]
        public Func<T, TreeNodeType>? ItemTypeSelector { get; set; }

        [Parameter]
        public EventCallback<T> ItemSelected { get; set; }

        [Parameter]
        public Func<T, string>? KeySelector { get; set; }


        public bool IsExpanded { get; set; }

        public bool IsSelected { get; set; }

        protected override void OnInitialized()
        {
            if (ParentTree is null)
            {
                throw new ArgumentException("TreeViewItem must be contained in a TreeView.");
            }

            base.OnInitialized();
        }

        private void OnItemClick()
        {
            if (ItemTypeSelector is not null && 
                Source is not null &&
                ItemTypeSelector.Invoke(Source) == TreeNodeType.Folder)
            {
                IsExpanded = !IsExpanded;
            }

            ItemSelected.InvokeAsync(Source);

            if (ParentTree is not null)
            {
                ParentTree.SelectedNode = this;
            }
        }

        private string GetActiveClass()
        {
            if (ParentTree is not null &&
                ParentTree.SelectedNode == this)
            {
                return "bg-info";
            }
            
            return "bg-secondary";
        }
    }
}
