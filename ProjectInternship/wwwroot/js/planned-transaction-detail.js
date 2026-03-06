// Check form hop le
$("#mainForm").on("submit", function (e) {
    const form = $(this);
    if (!form.valid()) {
        e.preventDefault();
        return;
    }
    e.preventDefault();
    saveToLocalstorage();
    history.back();
});

// Thuc hien luu vao localstorage
function saveToLocalstorage() {
    const getValue = (name) => document.querySelector(`[name="${name}"]`)?.value ?? "";
    const getChecked = (name) => document.querySelector(`[name="${name}"]`)?.checked ?? false;

    const Denpyono = getValue("Denpyono");
    let Gyono = getValue("Gyono");

    if (!Gyono) {
        const maxGyono = getMaxGyono(Denpyono)
        Gyono = maxGyono ? maxGyono + 1 : 1;
    }
    const data = {
        Denpyono,
        Gyono,
        Idodt: getValue("Idodt"),
        ShuppatsuPlc: getValue("ShuppatsuPlc"),
        MokutekiPlc: getValue("MokutekiPlc"),
        Keiro: getValue("Keiro"),
        Kingaku: getValue("Kingaku"),
        IsCheckedToDelete: getChecked("IsCheckedToDelete")
    };

    const key = `PlannedTransactionDetail_${Denpyono}_${Gyono}`;
    localStorage.setItem(key, JSON.stringify(data));
}
// Tim maxGyono dua vao Denpyono
function getMaxGyono(denpyono) {
    let max = 0;

    for (let i = 0; i < localStorage.length; i++) {
        const key = localStorage.key(i);

        if (!key.startsWith("PlannedTransactionDetail_")) continue;

        const [, d, g] = key.split("_");

        if (d == denpyono) {
            const gyono = Number(g);
            if (gyono > max) max = gyono;
        }
    }

    return max;
}