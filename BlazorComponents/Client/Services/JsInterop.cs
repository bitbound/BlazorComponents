﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorComponents.Client.Services
{
    public interface IJsInterop
    {
        ValueTask AddBeforeUnloadHandler();

        ValueTask AddClassName(ElementReference element, string className);
        ValueTask Alert(string message);

        ValueTask AutoHeight();

        ValueTask<bool> Confirm(string message);

        ValueTask<int> GetCursorIndex(ElementReference terminalInput);

        ValueTask InvokeClick(string elementId);

        ValueTask OpenWindow(string url, string target);

        ValueTask PreventTabOut(ElementReference terminalInput);

        ValueTask<string> Prompt(string message);
        ValueTask Reload();

        ValueTask ScrollToElement(ElementReference element);

        ValueTask ScrollToEnd(ElementReference element);

        ValueTask SetStyleProperty(ElementReference element, string propertyName, string value);
        ValueTask StartDraggingY(ElementReference element, double clientY);
    }
    public class JsInterop : IJsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInterop(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public ValueTask AddBeforeUnloadHandler()
        {
            return _jsRuntime.InvokeVoidAsync("addBeforeUnloadHandler");
        }

        public ValueTask AddClassName(ElementReference element, string className)
        {
            return _jsRuntime.InvokeVoidAsync("addClassName", element, className);
        }

        public ValueTask Alert(string message)
        {
            return _jsRuntime.InvokeVoidAsync("invokeAlert", message);
        }

        public ValueTask AutoHeight()
        {
            return _jsRuntime.InvokeVoidAsync("autoHeight");
        }

        public ValueTask<bool> Confirm(string message)
        {
            return _jsRuntime.InvokeAsync<bool>("invokeConfirm", message);
        }

        public ValueTask<int> GetCursorIndex(ElementReference inputElement)
        {
            return _jsRuntime.InvokeAsync<int>("getSelectionStart", inputElement);
        }

        public ValueTask InvokeClick(string elementId)
        {
            return _jsRuntime.InvokeVoidAsync("invokeClick", elementId);
        }

        public ValueTask OpenWindow(string url, string target)
        {
            return _jsRuntime.InvokeVoidAsync("openWindow", url, target);
        }

        public ValueTask PreventTabOut(ElementReference terminalInput)
        {
            return _jsRuntime.InvokeVoidAsync("preventTabOut", terminalInput);
        }

        public ValueTask<string> Prompt(string message)
        {
            return _jsRuntime.InvokeAsync<string>("invokePrompt", message);
        }

        public ValueTask Reload()
        {
            return _jsRuntime.InvokeVoidAsync("reload");
        }

        public ValueTask ScrollToElement(ElementReference element)
        {
            return _jsRuntime.InvokeVoidAsync("scrollToElement", element);
        }

        public ValueTask ScrollToEnd(ElementReference element)
        {
            return _jsRuntime.InvokeVoidAsync("scrollToEnd", element);
        }
        public ValueTask SetStyleProperty(ElementReference element, string propertyName, string value)
        {
            return _jsRuntime.InvokeVoidAsync("setStyleProperty", element, propertyName, value);
        }
        public ValueTask StartDraggingY(ElementReference element, double clientY)
        {
            return _jsRuntime.InvokeVoidAsync("startDraggingY", element, clientY);
        }
    }
}
