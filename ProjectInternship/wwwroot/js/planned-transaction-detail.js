function saveToLocalstorage() {

    // Key (Denpyono v Gyono)
    const Denpyono =

        document.querySelector(
            '[name="Denpyono"]'
        ).value;

    const Gyono =

        document.querySelector(
            '[name="Gyono"]'
        ).value;


    // =======================
    // DATA
    // =======================

    const data = {

        Denpyono,

        Gyono,

        Idodt:
            document.querySelector(
                '[name="Idodt"]'
            ).value,

        ShuppatsuPlc:
            document.querySelector(
                '[name="ShuppatsuPlc"]'
            ).value,

        MokutekiPlc:
            document.querySelector(
                '[name="MokutekiPlc"]'
            ).value,

        Keiro:
            document.querySelector(
                '[name="Keiro"]'
            ).value,

        Kingaku:
            document.querySelector(
                '[name="Kingaku"]'
            ).value,

        isCheckedToDelete:

            document.querySelector(
                '[name="isCheckedToDelete"]'
            )?.checked ?? false

    };


    // =======================
    // KEY
    // =======================

    const key =

        `PlannedTransactionDetail_${Denpyono}_${Gyono}`;

    console.log("SAVE KEY :", key);


    // =======================
    // UPDATE OR INSERT
    // =======================

    // localStorage.setItem()

    // tự overwrite nếu tồn tại

    // tự insert nếu chưa có

    localStorage.setItem(

        key,

        JSON.stringify(data)

    );


    alert("保存しました");

}