// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function scrollToLeft() {
    var container = document.querySelector('.scrollable-container');
    container.scrollBy({
        left: -200,
        behavior: 'smooth'
    });
    updateScrollButtons(); // Call the function to update button visibility
}

function scrollRight() {
    document.querySelector('.scrollable-container').scrollBy({
        left: 200,
        behavior: 'smooth'
    });
    updateScrollButtons(); // Call the function to update button visibility
}

function updateScrollButtons() {
    var container = document.querySelector('.scrollable-container');
    var leftButton = document.querySelector('.left-button');
    var rightButton = document.querySelector('.right-button');

    // If scrolled all the way to the left, hide left button
    if (container.scrollLeft === 0) {
        leftButton.style.display = 'none';
    } else {
        leftButton.style.display = 'block';
    }

    // If there's content to scroll to the right, show right button
    if (container.scrollWidth > container.clientWidth) {
        rightButton.style.display = 'block';
    } else {
        rightButton.style.display = 'none';
    }

    // If there's no more content to scroll to the right, hide right button
    if (container.scrollLeft + container.clientWidth >= container.scrollWidth) {
        rightButton.style.display = 'none';
    }
}



window.onload = function () {
    updateScrollButtons(); // Initially hide/show buttons based on scroll position

    // Add event listener for scroll event
    var container = document.querySelector('.scrollable-container');
    container.addEventListener('scroll', updateScrollButtons);
};


// popup
document.getElementById('registrationForm').addEventListener('submit', function (event) {
    event.preventDefault();

    var form = event.target;
    var formData = new FormData(form);

    fetch(form.action, {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) {
                var registrationSuccessModal = new bootstrap.Modal(document.getElementById('registrationSuccessModal'));
                registrationSuccessModal.show();
                setTimeout(function () {
                    window.location.href = '/Home/SignIn';
                }, 2000);
            } else {
                var registrationErrorModal = new bootstrap.Modal(document.getElementById('registrationErrorModal'));
                registrationErrorModal.show();
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
});

document.getElementById('payment-form').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default form submission

    // Get form data
    var formData = new FormData(this);

    // Send a POST request to the server with form data
    fetch(this.action, {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.text(); // Parse response body as text
        })
        .then(data => {
            // Display payment confirmation message
            document.getElementById('payment-message').innerHTML = data;
        })
        .catch(error => {
            console.error('There was an error with the fetch operation:', error);
        });
});


