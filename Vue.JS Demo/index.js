var app = new Vue({
    el: '#app',
    data: {
      message: 'Hello Vue!',
        _welcomeMessage: 'Welcome to the world of vue.JS programming.',
      get welcomeMessage() {
          return this._welcomeMessage;
      },
      set welcomeMessage(value) {
          this._welcomeMessage = value;
      },
    }
  });

  var personApp = new Vue({
    el: '#personApp',
    data: {
        firstName: 'Richard Jones',
        _lastName : 'Jones',
        // Setters and getters for properites.
        get LastName() {
            return this._lastName;
        },
        set LastName(value) {
            this._lastName = value;
        },
    }
  });