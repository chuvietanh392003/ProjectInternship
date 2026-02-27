function saveToLocalstorage() {

    const Denpyono =
        document.querySelector('[name="Denpyono"]').value;

    const Gyono =
        document.querySelector('[name="Gyono"]').value;

    const data = {

        Denpyono: Denpyono,

        Gyono: Gyono,

        Idodt:
            document.querySelector('[name="Idodt"]').value,

        ShuppatsuPlc:
            document.querySelector('[name="ShuppatsuPlc"]').value,

        MokutekiPlc:
            document.querySelector('[name="MokutekiPlc"]').value,

        Keiro:
            document.querySelector('[name="Keiro"]').value,

        Kingaku:
            document.querySelector('[name="Kingaku"]').value,

        isCheckedToDelete:
           document.querySelector('[name="isCheckedToDelete"]').checked

    };

    const key =
        `PlannedTransactionDetail_${Denpyono}_${Gyono}`;

    localStorage.setItem(
        key,
        JSON.stringify(data)
    );

    alert("保存しました");
}


