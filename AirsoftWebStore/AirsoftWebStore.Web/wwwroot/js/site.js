document.getElementById('dropdownMenuButton').addEventListener('click', showItems)

function showItems() {
    document.getElementById('dropdownItems').classList.toggle('show')
}

document.body.addEventListener('click', function (event) {
    const dropdownItems = document.getElementById('dropdownItems');
    const dropdownButton = document.getElementById('dropdownMenuButton');

    // Check if the clicked element is not inside the dropdown
    if (!dropdownItems.contains(event.target) && event.target !== dropdownButton) {
        dropdownItems.classList.remove('show');
    }
})