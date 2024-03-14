// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document
  .getElementById("createAccountForm")
  .addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent the default form submission
    var formData = new FormData(this); // Get form data
    fetch("/api/create_user", {
      // Send form data to the server
      method: "POST",
      body: formData,
      headers: {
        "Authorization": "Bearer ",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        // Handle the response from the server
        console.log(data); // You can do something based on the response
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  });
