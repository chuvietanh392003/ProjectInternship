document.addEventListener("click", function (e) {

    const row = e.target.closest(".planned-row");

    if (!row) return;

    const url = row.dataset.url;

    if (url) {

        location.href = url;

    }

});