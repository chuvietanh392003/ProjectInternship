/**
 * --------------------------------------------------------------------
 * Function Name : LoadTransactionDetailsToLocalStorage
 * Description   :
 *      Load transaction detail records from server data (serverDetails)
 *      and store them into browser localStorage.
 *
 * Process :
 *      1. Execute when DOMContentLoaded event fires.
 *      2. Retrieve transaction number (Denpyono) from form input.
 *      3. If data already exists, skip loading to avoid overwriting.
 *      4. Store each detail record into localStorage using key format:
 *             PlannedTransactionDetail_{Denpyono}_{Gyono}
 * --------------------------------------------------------------------
 */
document.addEventListener("DOMContentLoaded", function () {

    const denpyono =
        document.querySelector('[name="Denpyono"]')?.value;

    if (!denpyono) return;

    const existed = Object.keys(localStorage).some(key =>
        key.startsWith(`PlannedTransactionDetail_${denpyono}_`)
    );

    if (existed) return;

    serverDetails.forEach(item => {

        let formattedDate = "";

        if (item.Idodt) {
            const d = new Date(item.Idodt);
            formattedDate = d.toISOString().split("T")[0];
        }

        const newItem = {
            ...item,
            Idodt: formattedDate
        };

        const key =
            `PlannedTransactionDetail_${item.Denpyono}_${item.Gyono}`;

        localStorage.setItem(
            key,
            JSON.stringify(newItem)
        );
    });

});