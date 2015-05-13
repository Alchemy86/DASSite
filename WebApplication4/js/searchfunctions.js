function TickAllPR() {
    all = document.getElementById("filter_pr_all");
    if (all) {
        setCheckboxChecked("filter_pr_na", all.checked);
        setCheckboxChecked("filter_pr_0", all.checked);
        setCheckboxChecked("filter_pr_1", all.checked);
        setCheckboxChecked("filter_pr_2", all.checked);
        setCheckboxChecked("filter_pr_3", all.checked);
        setCheckboxChecked("filter_pr_4", all.checked);
        setCheckboxChecked("filter_pr_5", all.checked);
        setCheckboxChecked("filter_pr_6", all.checked);
        setCheckboxChecked("filter_pr_7", all.checked);
        setCheckboxChecked("filter_pr_8", all.checked);
        setCheckboxChecked("filter_pr_9", all.checked);
    }
}

function setCheckboxChecked(id, value) {
    cb = document.getElementById(id);
    if (cb) {
        cb.checked = value;
    }
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function selectEnds() {
    all = document.getElementById("ends_select_all");
    if (all) {
        setCheckboxChecked("ends_com", all.checked);
        setCheckboxChecked("ends_co", all.checked);
        setCheckboxChecked("ends_info", all.checked);
        setCheckboxChecked("ends_net", all.checked);
        setCheckboxChecked("ends_org", all.checked);
        setCheckboxChecked("ends_us", all.checked);
        setCheckboxChecked("ends_ca", all.checked);
        setCheckboxChecked("ends_mobi", all.checked);
        setCheckboxChecked("ends_biz", all.checked);
        setCheckboxChecked("ends_me", all.checked);
        setCheckboxChecked("ends_cc", all.checked);
        setCheckboxChecked("ends_tv", all.checked);
        setCheckboxChecked("ends_de", all.checked);
        setCheckboxChecked("ends_asia", all.checked);
        setCheckboxChecked("ends_se", all.checked);
        
        setCheckboxChecked("ends_au", all.checked);
        setCheckboxChecked("ends_ch", all.checked);
        setCheckboxChecked("ends_fr", all.checked);
        setCheckboxChecked("ends_ie", all.checked);
        setCheckboxChecked("ends_nu", all.checked);
        setCheckboxChecked("ends_pl", all.checked);
        setCheckboxChecked("ends_ru", all.checked);
        setCheckboxChecked("ends_uk", all.checked);
        setCheckboxChecked("ends_misc", all.checked);
        setCheckboxChecked("ends_su", all.checked);
        setCheckboxChecked("ends_at", all.checked);
        setCheckboxChecked("ends_be", all.checked);
        setCheckboxChecked("ends_eu", all.checked);
        setCheckboxChecked("ends_in", all.checked);
        setCheckboxChecked("ends_it", all.checked);
        setCheckboxChecked("ends_mx", all.checked);
        setCheckboxChecked("ends_nl", all.checked);
    }
}
