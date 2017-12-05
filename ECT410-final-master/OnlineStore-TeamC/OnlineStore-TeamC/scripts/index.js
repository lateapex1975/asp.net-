
window.onload=function() {
	switching_image();

};


function switching_image() {
	var photo_box = document.getElementById('photo_box');
	var oUl = photo_box.getElementsByTagName('ul')[0];
	var aLiUl = oUl.getElementsByTagName('li');
	
	var oOl = document.getElementsByTagName('ol')[0];
	var aLiOl = oOl.getElementsByTagName('li');
	
	for(var i=0;i<aLiOl.length;i++){
		aLiOl[i].index = i;
		aLiOl[i].onmouseover = function(){
			for(var i=0;i<aLiOl.length;i++){
				aLiOl[i].className = '';
				
				startMove( aLiUl[i],{opacity:0},function(){
					this.style.display = 'none';
					
			} );
				
			}
			this.className = 'active';
			aLiUl[this.index].style.display = 'block';
			startMove(aLiUl[this.index],{opacity:100});
		};
	}
}