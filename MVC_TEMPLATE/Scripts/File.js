<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

$(document).ready(function () {
        $(".image-container").each(function () {
            var container = $(this);
            var images = container.find("img");
            var currentIndex = 0;

            // Show the first image
            images.eq(currentIndex).show();

            // Attach click event to the previous button
            container.find(".prev-btn").click(function () {
                images.eq(currentIndex).hide();
                currentIndex = (currentIndex - 1 + images.length) % images.length;
                images.eq(currentIndex).show();
            });

            // Attach click event to the next button
            container.find(".next-btn").click(function () {
                images.eq(currentIndex).hide();
                currentIndex = (currentIndex + 1) % images.length;
                images.eq(currentIndex).show();
            });
        });

        $(document).ready(function () {
        $("#saveButton").click(function () {
        var selectedProducts = [];
        $(".product-checkbox:checked").each(function () {
            var productId = $(this).val();
            var title = $(this).data("title");
            var createdAt = $(this).data("createdat");

            selectedProducts.push({
                ProductId: productId,
                Title: title,
                CreatedAt: createdAt
            });
        });

        $.ajax({
            type: "POST",
            url: "@Url.Action("SaveSelectedProductsAsync", "Home")",
            data: JSON.stringify(selectedProducts), // Convert to JSON
            contentType: "application/json", // Set content type to JSON
            success: function (response) {
                if (response.success) {
                    alert("Selected products saved successfully!");
                } else {
                    alert("Failed to save selected products.");
                }
            },
            error: function () {
                alert("An error occurred while saving selected products.");
            }
        });
    });
});

 });

   
    

