async function loadData() {
    const res = await fetch(
      "https://apidata.mos.ru/v1/datasets/531/rows?api_key=0235c3e482940f862217a646e7c479f5"
    );
    const json = await res.json();

    json.forEach(async function (item) {
      const object = item.Cells;

      table.row
        .add([item.global_id, object.CommonName, object.WebSite])
        .draw(false);
    });
    table.processing(false);
  }

  table = $("#dt-table").DataTable({
    processing: true,
    responsive: true,
  });
  table.processing(true);

  loadData();