(function () {

    document.addEventListener(
        "DOMContentLoaded",
        renderDetailTable
    );

    function renderDetailTable() {

        const denpyono =
            document.querySelector(
                '[name="Denpyono"]'
            )?.value;

        const tbody =
            document.getElementById(
                "detailBody"
            );

        const totalCell =
            document.getElementById(
                "totalKingaku"
            );

        if (!denpyono || !tbody)
            return;

        tbody.innerHTML = "";

        //----------------------------------
        // get details from localStorage
        //----------------------------------

        const details = Object.keys(localStorage)

            .filter(key =>
                key.startsWith(
                    `PlannedTransactionDetail_${denpyono}_`
                ))

            .map(key =>
                JSON.parse(
                    localStorage.getItem(key)
                ))

            .sort(
                (a, b) =>
                    Number(a.Gyono) -
                    Number(b.Gyono)
            );

        //----------------------------------
        // render table
        //----------------------------------

        let total = 0;

        details.forEach((item, index) => {

            const tr =
                document.createElement("tr");

            tr.className =
                "detail-row";

            if (item.isCheckedToDelete) {
                tr.classList.add("deleted-row");
            }
                

            //----------------------------------
            // click edit
            //----------------------------------

            tr.onclick = () => {

                const params =
                    new URLSearchParams(item);

                params.set("isCreated", "true");
                params.set("isCheckedToDelete", "false");

                location.href =
                    "/PlannedTransactionDetail/Index?"
                + params.toString()
                //+ "isCreated=true"

            };

            //----------------------------------
            // html
            //----------------------------------

            tr.innerHTML = `

<td>
${index + 1}
</td>

<td>${item.Idodt ?? ""}</td>

<td>${item.ShuppatsuPlc ?? ""}</td>

<td>${item.MokutekiPlc ?? ""}</td>

<td>${item.Keiro ?? ""}</td>

<td>
${Number(item.Kingaku || 0).toLocaleString()}
</td>

`;

            tbody.appendChild(tr);

            //----------------------------------
            // total
            //----------------------------------
             total += Number(item.Kingaku || 0);

        });

        //----------------------------------
        // update total
        //----------------------------------

        if (totalCell)
            totalCell.innerText =
                total.toLocaleString();

    }

})();

