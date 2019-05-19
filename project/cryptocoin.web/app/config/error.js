//get erros from modelstate
function parseErrors(response) {
    var errors = [];
    for (var key in response.data.ModelState) {
        for (var i = 0; i < response.data.ModelState[key].length; i++) {
            errors.push(response.data.ModelState[key][i]);
        }
    }
    return errors;
}