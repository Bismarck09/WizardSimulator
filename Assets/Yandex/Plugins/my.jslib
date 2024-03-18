mergeInto(LibraryManager.library, {

  ShowAdv : function () {
    if (ysdk && ysdk.adv && ysdk.adv.showFullscreenAdv){
        ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage("GameManager", "CloseAdv");
        },
        onError: function(error) {
          
        }
        }
        })
    }
    },

  ShowAdvForCoins: function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: function() {
          console.log('Video ad open.');
        },
        onRewarded: function() {
          console.log('Rewarded!');
        },
        onClose: function() {
          myGameInstance.SendMessage("GameManager", "AddCoins");
        }, 
        onError: function() {
          console.log('Error while open video ad:', e);
        }
   }
   })
   },

  ShowAdvForPowerPotion: function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: function() {
          console.log('Video ad open.');
        },
        onRewarded: function() {
          console.log('Rewarded!');
        },
        onClose: function() {
          myGameInstance.SendMessage("GameManager", "AddPowerPotions");
        }, 
        onError: function() {
          console.log('Error while open video ad:', e);
        }
    }
    })
    },
});