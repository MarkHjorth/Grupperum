function shakeForm() {
    var l = 20;
    for( var i = 0; i < 10; i++ )
        $( "form" ).animate( {
                            'margin-left': "+=" + ( l = -l ) + 'px',
                            'margin-right': "-=" + l + 'px'
                            }, 50);  
    
}