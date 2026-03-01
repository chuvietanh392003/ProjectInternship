function saveToLocalstorage() {

    const Denpyono =
        document.querySelector(
            '[name="Denpyono"]').value;

    const Gyono =
        document.querySelector(
            '[name="Gyono"]').value;

    const data = {

        Denpyono,

        Gyono,

        Idodt:
            document.querySelector(
                '[name="Idodt"]').value,

        ShuppatsuPlc:
            document.querySelector(
                '[name="ShuppatsuPlc"]').value,

        MokutekiPlc:
            document.querySelector(
                '[name="MokutekiPlc"]').value,

        Keiro:
            document.querySelector(
                '[name="Keiro"]').value,

        Kingaku:
            document.querySelector(
                '[name="Kingaku"]').value,

        isCheckedToDelete:
            document.querySelector(
                '[name="isCheckedToDelete"]'
            )?.checked ?? false
    };

    //----------------------------------
    // lấy toàn bộ detail cùng Denpyono
    //----------------------------------

    let details = [];

    Object.keys(localStorage)
        .forEach(key => {

            if (
                key.startsWith(
                    `PlannedTransactionDetail_${Denpyono}_`
                )
            ) {

                details.push(

                    JSON.parse(
                        localStorage.getItem(key)
                    )

                );
            }

        });

    //----------------------------------
    // UPDATE OR INSERT
    //----------------------------------

    const index =
        details.findIndex(x =>
            x.Gyono == Gyono);

    if (index >= 0)

        details[index] = data;

    else

        details.push(data);


    //----------------------------------
    // REORDER 行 (Gyono)
    //----------------------------------

    // bỏ item delete nếu muốn skip numbering
    const activeRows =
        details
            .filter(x => !x.isCheckedToDelete)

            .sort((a, b) =>
                (a.Gyono - b.Gyono)
            );

    activeRows.forEach((x, i) => {

        x.Gyono = i + 1;

    });

    //----------------------------------
    // clear old keys
    //----------------------------------

    Object.keys(localStorage)
        .forEach(key => {

            if (
                key.startsWith(
                    `PlannedTransactionDetail_${Denpyono}_`
                )
            ) {

                localStorage.removeItem(key);

            }

        });

    //----------------------------------
    // save lại
    //----------------------------------

    details.forEach(item => {

        const key =
            `PlannedTransactionDetail_${Denpyono}_${item.Gyono}`;

        localStorage.setItem(
            key,
            JSON.stringify(item)
        );

    });

    alert("保存しました");
}