<script>
    // Replace "purchaseButtonId" with the ID of your purchase button.
    // You may need to adjust the selector depending on your actual button setup.
    document.getElementById("purchaseButton").addEventListener("click", function () {

        if (totalAmount > userBalance) {
        document.getElementById("purchaseErrorMessage").style.display = "block";
            // Prevent the form from being submitted if needed.
            // For example, if the purchase is done through a form submission.
            event.preventDefault();
        }
    });
</script>