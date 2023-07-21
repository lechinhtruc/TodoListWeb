function Load() {
    $.ajax({
        type: 'GET',
        url: '/api/GetAllJob',
        contentType: 'application/json',
        beforeSend: function (xhr) {
            //$(".modal").show();
        },
        success: function (response) {
            //if (response.Status === "success") {
            //    /*$("#lblTime").html(response.Time);*/
            //}
            BindDataToTable('.jobTable', response)
        },
        complete: function () {
            //$(".modal").hide();
        },
    });
}

function GetJobDetail() {

}

function BindDataToTable(table, data) {
    let tr = ''
    $.each(data, (index, job) => {
        tr += `<tr class="align-middle">`
        tr += `
        <td>${job.jobName}</td>`
        tr += ` 
        <td>
            <span class="badge rounded-pill bg-danger">${job.isDone}</span>
        </td>`
        tr += `
        <td>
            <a class="btn btn-primary btn-sm" href='/Update/?Id=${job.id}'><i class="bi bi-pencil-square"></i></a>
            <button class="btn btn-danger btn-sm" data-bs-toggle="modal" data-bs-target="@("#deleteJob-${job.id}"" > <i class="bi bi-trash3-fill"></i></button >
       </td>`
        tr += `</tr>`
    })
    $(table + ' > tbody').append(tr)
}