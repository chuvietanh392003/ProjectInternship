/**
 * -------------------------------------------------------
 * File Name   : department-modal.js
 * Description : Handles department modal events and actions
 * -------------------------------------------------------
 */
(function () {

    /**
     * -------------------------------------------------------
     * Function : closeModel
     * Description : Close the department selection modal
     * -------------------------------------------------------
     */

    window.closeModel = function () {

        const modalEl =
            document.getElementById('bumonModal');

        const modal =
            bootstrap.Modal.getOrCreateInstance(modalEl);

        modal.hide();
    }


    /**
     * -------------------------------------------------------
     * Function : selectBumon
     * Description : Set selected department code and name to the 
     * main form inputs
     * -------------------------------------------------------
     */

    window.selectBumon = function () {

        const selected =
            document.querySelector(
                'input[name="selectedBumon"]:checked');

        if (!selected) {
            alert("部門を選択してください");
            return;
        }

        const code = selected.value;
        const name = selected.dataset.name; 

        const codeInput = document.getElementById("BumoncdYkanr");
        const nameInput = document.getElementById("BumoncdName");

        codeInput.value = code;
        nameInput.value = name;

        codeInput.dispatchEvent(new Event('input'));

        closeModel();
    };

    /**
     * -------------------------------------------------------
     * Function : searchBumon
     * Description : Execute department search in the modal
     *               and reload the search result
     * -------------------------------------------------------
     */

    window.searchBumon = function (e) {

        e.preventDefault();

        const formData =
            new FormData(e.target);
        fetch('/Department/Index?' +
            new URLSearchParams(formData))

            .then(r => r.text())
            .then(html => {

                document.getElementById(
                    "bumonModalBody")
                    .innerHTML = html;

            });
    };

    /**
     * -------------------------------------------------------
     * Function : initDepartmentModal
     * Description : Initialize department modal and
     *               load department list when button clicked
     * -------------------------------------------------------
     */

    function initDepartmentModal() {

        const btn =
            document.getElementById(
                "openBumonModal");

        if (!btn) return;

        btn.addEventListener("click", function () {

            fetch("/Department/Index")

                .then(r => r.text())

                .then(html => {

                    document.getElementById(
                        "bumonModalBody")
                        .innerHTML = html;

                    new bootstrap.Modal(
                        document.getElementById(
                            "bumonModal"))

                        .show();

                });

        });

    }
    // Load departmnet modal
    document.addEventListener(
        "DOMContentLoaded",
        initDepartmentModal);

})();

/**
 * -------------------------------------------------------
 * Function : Auto Load Department Name From Department 
 * Code input
 * Description : Automatically retrieve department name
 *               when department code is entered
 * -------------------------------------------------------
 */

document.addEventListener("DOMContentLoaded", function () {

    const codeInput = document.getElementById("BumoncdYkanr");
    const nameInput = document.getElementById("BumoncdName");

    if (!codeInput) {
        return;
    }

    codeInput.addEventListener("input", function () {

        const code = codeInput.value;

        if (!code) {
            nameInput.value = "";
            return;
        }

        fetch('/PlannedTransactionRegistration/GetDepartmentName?departmentCode=' + code)
            .then(response => response.json())
            .then(data => {
                nameInput.value = data ?? "";
            })
            .catch(error => {
                nameInput.value = "";
            });
    });

});

/**
 * -------------------------------------------------------
 * Function : selectRow
 * Description : When a table row is clicked,
 *               automatically select the radio button
 * -------------------------------------------------------
 */

function selectRow(row) {
    const radio = row.querySelector('input[type="radio"]');
    if (radio) {
        radio.checked = true;
    }
}