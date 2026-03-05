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

        const code = selected.value;
        const name = selected.dataset.name; // lấy từ data-name

        const codeInput = document.getElementById("BumoncdYkanr");
        const nameInput = document.getElementById("BumoncdName");

        codeInput.value = code;
        nameInput.value = name;

        // Nếu bạn vẫn dùng event input để load name từ server
        codeInput.dispatchEvent(new Event('input'));

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