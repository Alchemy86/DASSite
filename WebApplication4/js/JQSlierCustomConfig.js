//<!-- PageRank Slider
$("#PRSilder").editRangeSlider();
$("#PRSilder").editRangeSlider("bounds", 0, 10);
$("#PRSilder").editRangeSlider("values", 0, 10);

// Change hidden field values to be read when user makes changes
$("#PRSilder").bind("valuesChanged", function (e, data) {
    var editValues = $("#PRSilder").editRangeSlider("values");
    $('#PageRankHiddenMin').val(Math.round(editValues.min));
    $('#PageRankHiddenMax').val(Math.round(editValues.max));
});

//-->

//<!-- CitationFlowSlider Slider
$("#CFSilder").editRangeSlider();
$("#CFSilder").editRangeSlider("bounds", 0, 10);
$("#CFSilder").editRangeSlider("values", 0, 10);
// Change hidden field values to be read when user makes changes
$("#CFSilder").bind("valuesChanged", function (e, data) {
    var editValues = $("#CFSilder").editRangeSlider("values");
    $('#CitationFlowHiddenMin').val(Math.round(editValues.min));
    $('#CitationFlowHiddenMax').val(Math.round(editValues.max));
});
//-->

//<!-- DOmain Ago Slider
$("#DomainAge").editRangeSlider();
$("#DomainAge").editRangeSlider("bounds", 0, 30);
$("#DomainAge").editRangeSlider("values", 0, 30);
// Change hidden field values to be read when user makes changes
$("#DomainAge").bind("valuesChanged", function (e, data) {
    var editValues = $("#DomainAge").editRangeSlider("values");
    $('#DomainAgeHiddenMin').val(Math.round(editValues.min));
    $('#DomainAgeHiddenMax').val(Math.round(editValues.max));
});

//-->

//<!-- Domain Price Slider
$("#DomainPrice").editRangeSlider();
$("#DomainPrice").editRangeSlider("bounds", 0, 99999);
$("#DomainPrice").editRangeSlider("values", 0, 99999);
// Change hidden field values to be read when user makes changes
$("#DomainPrice").bind("valuesChanged", function (e, data) {
    var editValues = $("#DomainPrice").editRangeSlider("values");
    $('#DomainPriceHiddenMin').val(Math.round(editValues.min));
    $('#DomainPriceHiddenMax').val(Math.round(editValues.max));
});
//-->

//<!-- Majestic Backlinks Slider
$("#MABacklinks").editRangeSlider();
$("#MABacklinks").editRangeSlider("bounds", 0, 99999);
$("#MABacklinks").editRangeSlider("values", 0, 99999);
// Change hidden field values to be read when user makes changes
$("#MABacklinks").bind("valuesChanged", function (e, data) {
    var editValues = $("#MABacklinks").editRangeSlider("values");
    $('#MajesticBacklinksHiddenMin').val(Math.round(editValues.min));
    $('#MajesticBacklinksHiddenMax').val(Math.round(editValues.max));
});
//-->


//<!-- Majestic Trustflow Slider
$("#MATrustFlow").editRangeSlider();
$("#MATrustFlow").editRangeSlider("bounds", 0, 10);
$("#MATrustFlow").editRangeSlider("values", 0, 10);
// Change hidden field values to be read when user makes changes
$("#MATrustFlow").bind("valuesChanged", function (e, data) {
    var editValues = $("#MATrustFlow").editRangeSlider("values");
    $('#MajesticTrustflowHiddenMin').val(Math.round(editValues.min));
    $('#MajesticTrustflowHiddenMax').val(Math.round(editValues.max));
});
//-->

//<!-- MOZPA Trustflow Slider
$("#MOZPA").editRangeSlider();
$("#MOZPA").editRangeSlider("bounds", 0, 10);
$("#MOZPA").editRangeSlider("values", 0, 10);
// Change hidden field values to be read when user makes changes
$("#MOZPA").bind("valuesChanged", function (e, data) {
    var editValues = $("#MOZPA").editRangeSlider("values");
    $('#MOZPAHiddenMin').val(Math.round(editValues.min));
    $('#MOZPAHiddenMax').val(Math.round(editValues.max));
});
//-->

//<!-- MOZPA Trustflow Slider
$("#MOZDA").editRangeSlider();
$("#MOZDA").editRangeSlider("bounds", 0, 10);
$("#MOZDA").editRangeSlider("values", 0, 10);
// Change hidden field values to be read when user makes changes
$("#MOZDA").bind("valuesChanged", function (e, data) {
    var editValues = $("#MOZDA").editRangeSlider("values");
    $('#MOZDAHiddenMin').val(Math.round(editValues.min));
    $('#MOZDAHiddenMax').val(Math.round(editValues.max));
});
//-->

//<!-- MAJESTIC IPS Slider
$("#MajesticIPS").editRangeSlider();
$("#MajesticIPS").editRangeSlider("bounds", 0, 500);
$("#MajesticIPS").editRangeSlider("values", 0, 500);
// Change hidden field values to be read when user makes changes
$("#MajesticIPS").bind("valuesChanged", function (e, data) {
    var editValues = $("#MajesticIPS").editRangeSlider("values");
    $('#MajesticIPSHiddenMin').val(Math.round(editValues.min));
    $('#MajesticIPSHiddenMax').val(Math.round(editValues.max));
});
//-->

