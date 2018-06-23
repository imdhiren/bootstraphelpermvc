HTML helper is a method that returns a HTML string. Then this string is rendered in view. MVC provides many HTML helper methods. It also provides facility to create your own HTML helper methods. Once you create your helper method you can reuse it many times.

1:-TextBoxFor
@Html.TextBoxRowFor(x => x.LoginViewModels.UserName, new { @Placeholder = "Enter User Name" })

OutPut:-
<div class="form-group">
   <label class="control-label col-lg-2" for="LoginViewModels_UserName">UserName</label>
   <div class="col-lg-10">
   <input placeholder="Enter User Name" class="form-control" id="LoginViewModels_UserName" name="LoginViewModels.UserName" type="text" value="">
   <span class="field-validation-valid help-inline" data-valmsg-for="LoginViewModels.UserName" data-valmsg-replace="true"></span>
   </div>
</div>

2:-PasswordFor
@Html.PasswordRowFor(x => x.LoginViewModels.Password, new { placeholder = "Enter Password" })

OutPut:-

<div class="form-group">
    <label class="control-label col-lg-2" for="LoginViewModels_Password">Password</label>
    <div class="col-lg-10">
        <input class="form-control" id="LoginViewModels_Password" name="LoginViewModels.Password" placeholder="Enter Password" type="password" value="">
        <span class="field-validation-valid help-inline" data-valmsg-for="LoginViewModels.Password" data-valmsg-replace="true"></span>
    </div>
</div>

and many more i upload soon..
