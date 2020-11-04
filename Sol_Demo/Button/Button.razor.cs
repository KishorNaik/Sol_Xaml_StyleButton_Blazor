using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ButtonWpf
{
    public partial class Button
    {
        #region Private Property

        private String ButtonClass { get; set; }

        private bool IsLoad { get; set; }

        #endregion Private Property

        #region Protected Method

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoad = true;
                base.StateHasChanged();
            }
        }

        #endregion Protected Method

        #region Public Property

        [Parameter]
        public EventCallback OnClick { get; set; }

        [Parameter]
        public String Id { get; set; }

        [Parameter]
        public String Content { get; set; }

        #region Brush Section

        [Parameter]
        public String Foreground { get; set; }

        [Parameter]
        public String Background { get; set; }

        [Parameter]
        public String BorderBrush { get; set; }

        [Parameter]
        public int? BorderThickness { get; set; }

        [Parameter]
        public int? BorderRadius { get; set; }

        #endregion Brush Section

        #region Layout

        [Parameter]
        public int? Height { get; set; }

        [Parameter]
        public int? Width { get; set; }

        [Parameter]
        public String Margin
        {
            get; set;
        }

        private String SetMargin()
        {
            var _margin = this.Margin;
            int counter = 0;

            if (_margin != null)
            {
                if (_margin.Contains(","))
                {
                    string[] marginValues = Regex.Split(_margin, ",");

                    string top = null;
                    string right = null;
                    string bottom = null;
                    string left = null;
                    var stringBuilder = new StringBuilder();

                    foreach (var item in marginValues)
                    {
                        if (counter == 0)
                        {
                            top = item + "px";
                            _margin = top;
                        }
                        else if (counter == 1)
                        {
                            right = item + "px";

                            _margin = stringBuilder.Append(top).Append(" ").Append(right).ToString();
                        }
                        else if (counter == 2)
                        {
                            bottom = item + "px";
                            _margin = stringBuilder.Append(" ").Append(bottom).ToString();
                        }
                        else if (counter == 3)
                        {
                            left = item + "px";
                            _margin = stringBuilder.Append(" ").Append(left).ToString();
                        }
                        counter++;
                    }
                }
                else
                {
                    _margin = _margin + "px";
                }
            }

            return _margin;
        }

        [Parameter]
        public String Padding { get; set; }

        private String SetPadding()
        {
            var _padding = this.Padding;
            int counter = 0;

            if (_padding != null)
            {
                if (_padding.Contains(","))
                {
                    string[] paddingValues = Regex.Split(_padding, ",");

                    string top = null;
                    string right = null;
                    string bottom = null;
                    string left = null;
                    var stringBuilder = new StringBuilder();

                    foreach (var item in paddingValues)
                    {
                        if (counter == 0)
                        {
                            top = item + "px";
                            _padding = top;
                        }
                        else if (counter == 1)
                        {
                            right = item + "px";

                            _padding = stringBuilder.Append(top).Append(" ").Append(right).ToString();
                        }
                        else if (counter == 2)
                        {
                            bottom = item + "px";
                            _padding = stringBuilder.Append(" ").Append(bottom).ToString();
                        }
                        else if (counter == 3)
                        {
                            left = item + "px";
                            _padding = stringBuilder.Append(" ").Append(left).ToString();
                        }
                        counter++;
                    }
                }
                else
                {
                    _padding = _padding + "px";
                }
            }

            return _padding;
        }

        #endregion Layout

        #region Font Section

        public int? FontSize { get; set; }

        #endregion Font Section

        #endregion Public Property
    }
}