const config = {
    apiPath: '/api',
    getJobPath: '/GetJobById',
    createJobPath: '/CreateJob',
    deleteJobPath: '/DeleteJob',
    updateJobPath: '/UpdateJob',
}

const text = {
    deleteConfirm: 'Bạn có chắc chắn muốn xoá công việc:',
    deleteModalTitle: 'Xoá công việc'
}


const DeleteJob = (jobId) => {
    const url = config.apiPath + `${config.getJobPath}/${jobId}`
    $.ajax({
        url,
        contentType: 'application/json',
        success: function (job) {
            $('#jobId').val(job.id);
            $('#delete-modal .modal-title').text(text.deleteModalTitle)
            $('.delete-confirm').text(`${text.deleteConfirm} ${job.jobName}`);
            $('#delete-modal').modal("show");
        }
    })
}

$(document).ready(() => {
    $(`#delete-form`).on('submit', (e) => {
        e.preventDefault();

        const jobId = $('#jobId').val();
        $.ajax({
            type: 'DELETE',
            url: config.apiPath + `${config.deleteJobPath}/?id=${jobId}`,
            contentType: 'application/json',
            error: function (err) {
                throw err;
            },
            success: function (response) {
                //success handle
                $(`#job-${jobId}`).remove();
            },
            complete: function () {
                $('#delete-modal').modal("hide");
            },
        });
    })

    $('#update-form').on("submit", (e) => {
        e.preventDefault();

        const id = parseInt($('#jobId').val());
        const jobName = $('#jobInput').val().trim();
        const isDone = JSON.parse($('.form-select').val());
        const data = JSON.stringify({
            id,
            jobName,
            isDone
        });
        $.ajax({
            type: 'PATCH',
            url: config.apiPath + `${config.updateJobPath}`,
            contentType: 'application/json',
            data: data,
            error: function (err) {
                throw err;
            },
            success: function (response) {
                window.location.href = '/';
            },
        });
    })

    $('#create-form').on("submit", (e) => {
        e.preventDefault();
        const jobName = $('#jobInput').val();
        const data = JSON.stringify({
            jobName,
        });
        $.ajax({
            type: 'POST',
            url: config.apiPath + `${config.createJobPath}`,
            contentType: 'application/json',
            data: data,
            error: function (err) {
                throw err;
            },
            success: function (response) {
                window.location.href = '/';
            },
        })
    })
})

