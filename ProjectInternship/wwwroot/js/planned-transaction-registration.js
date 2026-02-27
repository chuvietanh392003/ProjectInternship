function closeModel() {
    const modalEl = document.getElementById('bumonModal');
    const modal = bootstrap.Modal.getOrCreateInstance(modalEl);
    modal.hide();
}
function selectBumon() {
    const selected = document.querySelector('input[name="selectedBumon"]:checked');

    if (!selected) {
        alert("部門を選択してください");
        return;
    }

    const code = selected.value;

    document.getElementById("BumoncdYkanr").value = code;
    closeModel();
}

function searchBumon(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    fetch('/Department/Index?' + new URLSearchParams(formData))
        .then(response => response.text())
        .then(data => {
            document.getElementById("bumonModalBody").innerHTML = data;
        });
}

function initDepartmentModal() {

    const btn = document.getElementById("openBumonModal");

    if (!btn) return;

    btn.addEventListener("click", function () {

        fetch("/Department/Index")
            .then(response => response.text())
            .then(data => {

                document.getElementById("bumonModalBody").innerHTML = data;

                const modalElement =
                    document.getElementById("bumonModal");

                const modal =
                    new bootstrap.Modal(modalElement);

                modal.show();
            });

    });

}

document.addEventListener("DOMContentLoaded", function () {

    initDepartmentModal();

});

function updateDetailTableFromLocalStorage() {
    const currentDenpyono =
        document.getElementById("Denpyono")?.value;

    const tbody =
        document.getElementById("detailBody");

    if (!tbody) return;

    const rows =
        tbody.querySelectorAll("tr");

    // map existing rows
    const existing = {};

    rows.forEach(row => {

        const denpyono =
            row.dataset.denpyono;

        const gyono =
            row.dataset.gyono;

        const key =
            `${denpyono}_${gyono}`;

        existing[key] = row;
    });

    // loop localStorage
    for (let i = 0; i < localStorage.length; i++) {

        const storageKey =
            localStorage.key(i);

        if (!storageKey.startsWith(
            "PlannedTransactionDetail_"))
            continue;

        const data =
            JSON.parse(
                localStorage.getItem(storageKey));
        if (data.Denpyono != currentDenpyono)
            continue;

        const key =
            `${data.Denpyono}_${data.Gyono}`;

        // ===== UPDATE =====

        if (existing[key]) {

            const row =
                existing[key];

            row.children[1].innerText =
                data.Idodt;

            row.children[2].innerText =
                data.ShuppatsuPlc;

            row.children[3].innerText =
                data.MokutekiPlc;

            row.children[4].innerText =
                data.Keiro;

            row.children[5].innerText =
                data.Kingaku;
            if (data.isCheckedToDelete) {
                row.classList.add("bg-dark", "text-white");
            }
            else {
                row.classList.remove("bg-dark", "text-white");
            }
        }
        // ===== INSERT =====

        else {

            const newRow =
                document.createElement("tr");

            newRow.dataset.denpyono =
                data.Denpyono;

            newRow.dataset.gyono =
                data.Gyono;

            newRow.innerHTML = `

<td></td>

<td>${data.Idodt ?? ""}</td>

<td>${data.ShuppatsuPlc ?? ""}</td>

<td>${data.MokutekiPlc ?? ""}</td>

<td>${data.Keiro ?? ""}</td>

<td>${data.Kingaku ?? ""}</td>

`;

            tbody.appendChild(newRow);
        }
    }
}

document.addEventListener(
    "DOMContentLoaded",
    function () {

        updateDetailTableFromLocalStorage();

    }
);

