using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Util.Buttons
{
    public static partial class HelperExtensions
    {
        public static IHtmlContent FormSubmitButton(this IHtmlHelper helper, string text = "Salvar", string customClass = "")
        {
            var button = $"<button id='btnSubmit' class='btn btn-primary {customClass}' type='submit'><i class='fa fa-save'></i> {text}</button>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormExcludeButton(this IHtmlHelper helper, string text = "Excluir", string faIcon = "fa fa-save")
        {
            var button = $"<button class='btn btn-danger' type='submit'><i class='{faIcon}'></i> {text}</button>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormInativar(this IHtmlHelper helper, string text = "Inativar", string faIcon = "fa fa-unlink ")
        {
            var button = $"<button class='btn btn-danger' type='submit'><i class='{faIcon}'></i> {text}</button>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormReativar(this IHtmlHelper helper, string text = "Reativar", string faIcon = "fa fa-link ")
        {
            var button = $"<button class='btn btn-primary' type='submit'><i class='{faIcon}'></i> {text}</button>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormCancelButton(this IHtmlHelper helper, string text = "Cancelar", string customClass = "", string url = "")
        {
            string p = "href='' onclick='history.go(-1); return false;' ";

            if (string.IsNullOrWhiteSpace(url) == false)
                p = $"href='{url}'";

            var button = $"<a {p} class='btn btn-default {customClass}'> {text}</a>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormCancelBackIndexButton(this IHtmlHelper helper)
        {
            var button = $"<a href='Index' class='btn btn-default'> Cancelar</a>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormBaixarExcelButton(this IHtmlHelper helper, string formAction)
        {
            var button = $"<button type='submit' class='btn btn-success btn-sm btnBaixarExcel' formaction='{formAction}'><i class='fa fa-file-excel-o'> Excel</i></button>";
            return new HtmlString(button);
        }

        public static IHtmlContent FormReportButton(this IHtmlHelper helper, string formAction, string nome = "Resumo")
        {
            var button = $"<button type='submit' class='btn btn-success btn-sm btnReport' formaction='{formAction}'><i class='fa fa-file-text-o'> {nome}</i></button>";
            return new HtmlString(button);
        }

        public static IHtmlContent NewButton(this IHtmlHelper helper, string action, string text = "Novo", string btnId = "")
        {
            var button = $"<a href='{action}' id='{btnId}' class='btn btn-sm btn-success'><i class='fa fa-plus'></i> {text}</a>";
            return new HtmlString(button);
        }

        public static IHtmlContent EditButton(this IHtmlHelper helper, string action, string text = "Editar")
        {
            var button = $"<a href='{action}' class='btn btn-sm btn-default'><i class='fa fa-file'></i> {text}</a>";
            return new HtmlString(button);
        }

        public static IHtmlContent UploadButton(this IHtmlHelper helper, string action)
        {
            var button = $"<a href='{action}' class='btn btn-sm btn-info'><i class='fa fa-upload'></i> Upload</a>";
            return new HtmlString(button);
        }

        public static IHtmlContent PageTitleButtons(this IHtmlHelper helper, params IHtmlContent[] buttonHelpers)
        {
            var container = $"<span class='jsMoveToPageTitle'>";

            foreach (var button in buttonHelpers)
                container += "&nbsp;" + button;

            container += "</span>";

            return new HtmlString(container);
        }

        public static IHtmlContent BtnVoltar(this IHtmlHelper helper, string action)
        {
            var button = $"<a href='{action}' class='btn btn-sm btn-success'><i class='fa fa-backward'></i> Voltar</a>";
            return new HtmlString(button);
        }

        public static HtmlString PrintButton(this IHtmlHelper helper)
        {
            var button = $"&nbsp;<button class='btn btn-primary notprint' onclick='window.print();'><i class='fa fa-print'></i> Imprimir</button>";

            return new HtmlString(button);
        }
    }
}
