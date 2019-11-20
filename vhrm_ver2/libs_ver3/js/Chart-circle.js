FusionCharts.ready(function () {
    var revenueChart = new FusionCharts({
        type: 'doughnut2d',
        renderAt: 'chart-container2',
        width: '100%',
        height: '300',
        dataFormat: 'json',
        dataSource: {
            "chart": {
                "caption": "Split of Revenue by Product Categories",
              /*  "subCaption": "Last year",*/
                "numberPrefix": "$",
                "paletteColors": "#0075c2, #1aaf5d, #f2c500, #f45b00,#8e0000",
                "bgColor": "#ffffff",
                "showBorder": "0",
                "use3DLighting": "0",
                "showShadow": "0",
                "enableSmartLabels": "0",
                "startingAngle": "310",
                "showLabels": "0",
                "showPercentValues": "1",
                "showLegend": "1",
                "legendShadow": "0",
                "legendBorderAlpha": "0",
              /*  "defaultCenterLabel": "Total revenue: $64.08K",
                "centerLabel": "Revenue from $label: $value", */
                "centerLabelBold": "1",
                "showTooltip": "0",
                "decimals": "0",
                "captionFontSize": "14",
                "subcaptionFontSize": "14",
                "subcaptionFontBold": "0"
            },
            "data": [
                {
                    "label": "Food",
                    "value": "450"
                }, 
                {
                    "label": "Apparels",
                    "value": "460"
                }, 
                {
                    "label": "Electronics",
                    "value": "500"
                }, 
                {
                    "label": "Household",
                    "value": "420"
                }
				, 
                {
                    "label": "water",
                    "value": "490"
                }
            ]
        }
    }).render();
});