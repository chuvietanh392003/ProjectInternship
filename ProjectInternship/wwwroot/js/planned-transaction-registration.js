(function () {

    document.addEventListener("DOMContentLoaded", renderDetailTable);

    function renderDetailTable() {

        const denpyono = document
            .querySelector('[name="Denpyono"]')
            ?.value;

        const tbody = document
            .getElementById("detailBody");

        const totalCell = document
            .getElementById("totalKingaku");

        if (!denpyono || !tbody) return;

        tbody.innerHTML = "";

        const details = Object.keys(localStorage)
            .filter(key =>
                key.startsWith(`PlannedTransactionDetail_${denpyono}_`)
            )
            .map(key =>
                JSON.parse(localStorage.getItem(key))
            )
            .sort((a, b) =>
                Number(a.Gyono) - Number(b.Gyono)
            );

        let total = 0;

        details.forEach((item, index) => {

            const tr = document.createElement("tr");

            tr.className = "detail-row";

            if (item.isCheckedToDelete) {
                tr.classList.add("deleted-row");
            }

            tr.onclick = () => {

                const params = new URLSearchParams(item);

                params.set("IsCreated", "true");
                params.set("isCheckedToDelete", "false");

                location.href =
                    "/PlannedTransactionDetail/Index?" +
                    params.toString();
            };

            tr.innerHTML = `
<td>${index + 1}</td>
<td>${item.Idodt ?? ""}</td>
<td>${item.ShuppatsuPlc ?? ""}</td>
<td>${item.MokutekiPlc ?? ""}</td>
<td>${item.Keiro ?? ""}</td>
<td>${Number(item.Kingaku || 0).toLocaleString()}</td>
`;

            tbody.appendChild(tr);

            total += Number(item.Kingaku || 0);
        });

        if (totalCell) {
            totalCell.innerText = total.toLocaleString();
        }
    }

})();


function prepareResultsBeforeSubmit() {

    const form = document.getElementById("mainForm");

    const denpyono = document
        .querySelector('[name="Denpyono"]')
        ?.value;

    if (!denpyono) return;

    form.querySelectorAll(".detail-hidden")
        .forEach(x => x.remove());

    let index = 0;

    Object.keys(localStorage)
        .filter(key =>
            key.startsWith(`PlannedTransactionDetail_${denpyono}_`)
        )
        .forEach(key => {

            const item = JSON.parse(localStorage.getItem(key));

            addHidden(form, `Results[${index}].Denpyono`, item.Denpyono);
            addHidden(form, `Results[${index}].Gyono`, item.Gyono);
            addHidden(form, `Results[${index}].Idodt`, item.Idodt);
            addHidden(form, `Results[${index}].ShuppatsuPlc`, item.ShuppatsuPlc);
            addHidden(form, `Results[${index}].MokutekiPlc`, item.MokutekiPlc);
            addHidden(form, `Results[${index}].Keiro`, item.Keiro);
            addHidden(form, `Results[${index}].Kingaku`, item.Kingaku);
            addHidden(form, `Results[${index}].isCheckedToDelete`, item.isCheckedToDelete);

            index++;
        });
}


function addHidden(form, name, value) {

    const input = document.createElement("input");

    input.type = "hidden";
    input.name = name;
    input.value = value ?? "";
    input.className = "detail-hidden";

    form.appendChild(input);
}