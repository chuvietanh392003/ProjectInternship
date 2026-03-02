(function () {

    window.closeModel = function () {

        const modalEl =
            document.getElementById('bumonModal');

        const modal =
            bootstrap.Modal.getOrCreateInstance(modalEl);

        modal.hide();
    }

    window.selectBumon = function () {

        const selected =
            document.querySelector(
                'input[name="selectedBumon"]:checked');

        if (!selected) {

            alert("部門を選択してください");
            return;
        }

        document.getElementById(
            "BumoncdYkanr").value =
            selected.value;

        closeModel();
    };

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

    document.addEventListener(
        "DOMContentLoaded",
        initDepartmentModal);

})();